using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Neato.Nucleo.Protocol;
using I8Beef.Neato.Nucleo.Protocol.Services.Common;
using I8Beef.Neato.Nucleo.Protocol.Services.GeneralInfo;
using I8Beef.Neato.Nucleo.Protocol.Services.HouseCleaning;
using I8Beef.Neato.Nucleo.Protocol.Services.LocalStats;
using I8Beef.Neato.Nucleo.Protocol.Services.ManualCleaning;
using I8Beef.Neato.Nucleo.Protocol.Services.Maps;
using I8Beef.Neato.Nucleo.Protocol.Services.Preferences;
using I8Beef.Neato.Nucleo.Protocol.Services.Schedule;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo
{
    /// <inheritdoc />
    public class NucleoClient : INucleoClient
    {
        private const string _acceptHeader = "application/vnd.neato.nucleo.v1";
        private const string _nucleoUrl = "https://nucleo.neatocloud.com";
        private const string _nucleoMessageEndpoint = "vendors/neato/robots/{serialNumber}/messages";

        private static readonly HttpClientHandler _httpClientHandler = new HttpClientHandler { ClientCertificateOptions = ClientCertificateOption.Manual };
        private static readonly HttpClient _httpClient = new HttpClient(_httpClientHandler) { Timeout = Timeout.InfiniteTimeSpan };
        private readonly string _serialNumber;
        private readonly string _secretKey;

        private int _requestId = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="NucleoClient"/> class.
        /// </summary>
        /// <param name="serialNumber">Serial number.</param>
        /// <param name="secretKey">Secret key.</param>
        public NucleoClient(string serialNumber, string secretKey)
        {
            _serialNumber = serialNumber ?? throw new ArgumentNullException(nameof(serialNumber));
            _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));

            _httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        }

        #region Common

        /// <inheritdoc />
        public async Task<StandardResponse<EmptyResponse>> DismissCurrentAlertAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.DismissCurrentAlert);

        /// <inheritdoc />
        public async Task<StandardResponse<RobotInfo>> GetRobotInfoAsync() => await SendCommandAsync<StandardResponse<RobotInfo>>(CommandType.GetRobotInfo);

        /// <inheritdoc />
        public async Task<StateResponse<EmptyResponse>> GetRobotStateAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.GetRobotState);

        #endregion

        #region FindMe

        /// <inheritdoc />
        public async Task<StandardResponse<EmptyResponse>> FindMeAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.FindMe);

        #endregion

        #region GeneralInfo

        /// <inheritdoc />
        public async Task<StandardResponse<GetGeneralInfo>> GetGeneralInfoAsync() => await SendCommandAsync<StandardResponse<GetGeneralInfo>>(CommandType.GetGeneralInfo);

        #endregion

        #region HouseCleaning and SpotCleaning

        /// <inheritdoc />
        public async Task<StateResponse<EmptyResponse>> StartCleaningAsync(StartCleaningParameters parameters) => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.StartCleaning, parameters);

        /// <inheritdoc />
        public async Task<StateResponse<EmptyResponse>> StopCleaningAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.StopCleaning);

        /// <inheritdoc />
        public async Task<StateResponse<EmptyResponse>> PauseCleaningAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.PauseCleaning);

        /// <inheritdoc />
        public async Task<StateResponse<EmptyResponse>> ResumeCleaningAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.ResumeCleaning);

        /// <inheritdoc />
        public async Task<StateResponse<EmptyResponse>> SendToBaseAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.SendToBase);

        #endregion

        #region LocalStats

        /// <inheritdoc />
        public async Task<StandardResponse<LocalStats>> GetLocalStatsAsync() => await SendCommandAsync<StandardResponse<LocalStats>>(CommandType.GetLocalStats);

        #endregion

        #region ManualCleaning

        /// <inheritdoc />
        public async Task<StandardResponse<RobotManualCleaningInfo>> GetRobotManualCleaningInfoAsync() => await SendCommandAsync<StandardResponse<RobotManualCleaningInfo>>(CommandType.GetRobotManualCleaningInfo);

        #endregion

        #region Maps

        /// <inheritdoc />
        public async Task<StandardResponse<MapBoundaries>> GetMapBoundariesAsync(GetMapBoundaries parameters) => await SendCommandAsync<StandardResponse<MapBoundaries>>(CommandType.GetMapBoundaries, parameters);

        /// <inheritdoc />
        public async Task<StandardResponse<EmptyResponse>> SetMapBoundariesAsync(SetMapBoundaries parameters) => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetMapBoundaries, parameters);

        /// <inheritdoc />
        public async Task<StandardResponse<EmptyResponse>> StartPersistentMapExplorationAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.StartPersistentMapExploration);

        #endregion

        #region Preferences

        /// <inheritdoc />
        public async Task<StandardResponse<Preferences>> GetPreferencesAdvanced1Async() => await SendCommandAsync<StandardResponse<Preferences>>(CommandType.GetPreferences);

        /// <inheritdoc />
        public async Task<StandardResponse<EmptyResponse>> SetPreferencesAdvanced1Async(Preferences parameters) => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetPreferences, parameters);

        #endregion

        #region Schedule

        /// <inheritdoc />
        public async Task<StandardResponse<Schedule>> GetScheduleAsync() => await SendCommandAsync<StandardResponse<Schedule>>(CommandType.GetSchedule);

        /// <inheritdoc />
        public async Task<StandardResponse<EmptyResponse>> SetScheduleAsync(Schedule parameters) => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetSchedule, parameters);

        /// <inheritdoc />
        public async Task<StandardResponse<EmptyResponse>> EnableScheduleAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.EnableSchedule);

        /// <inheritdoc />
        public async Task<StandardResponse<EmptyResponse>> DisableScheduleAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.DisableSchedule);

        #endregion

        /// <summary>
        /// Send a standard command.
        /// </summary>
        /// <typeparam name="TResponse">Type of response message.</typeparam>
        /// <param name="command">Command to send.</param>
        /// <param name="parameters">Parameters.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        private async Task<TResponse> SendCommandAsync<TResponse>(CommandType command, object parameters = null)
        {
            var request = new Request(_requestId, command, parameters);

            var serializedContent = JsonConvert.SerializeObject(request);
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(new Uri(_nucleoUrl), _nucleoMessageEndpoint.Replace("{serialNumber}", _serialNumber)),
                Content = new StringContent(serializedContent, Encoding.UTF8, "application/json")
            };

            using (var response = await SendRequestAsync(requestMessage))
            {
                // Bump request id
                _requestId++;

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Sends a request.
        /// </summary>
        /// <param name="requestMessage">Request message.</param>
        /// <returns>An <see cref="HttpResponseMessage"/>.</returns>
        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage)
        {
            var dateHeaderValue = DateTime.UtcNow.ToString("ddd, dd MMM yyy HH:mm:ss 'GMT'");
            var body = await requestMessage.Content.ReadAsStringAsync();

            byte[] secretkey = Encoding.UTF8.GetBytes(_secretKey);
            using (HMACSHA256 hmac = new HMACSHA256(secretkey))
            {
                var authString = string.Join("\n", _serialNumber.ToLower(), dateHeaderValue, body);

                var signature = hmac.ComputeHash(Encoding.UTF8.GetBytes(authString));

                // Add headers
                requestMessage.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(_acceptHeader));
                requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("NEATOAPP", BitConverter.ToString(signature).Replace("-", string.Empty).ToLower());
                requestMessage.Headers.Add("X-Date", dateHeaderValue);

                return await _httpClient.SendAsync(requestMessage);
            }
        }
    }
}
