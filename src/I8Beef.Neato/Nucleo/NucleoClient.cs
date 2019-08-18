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
    /// <summary>
    /// Nucleo client.
    /// </summary>
    public class NucleoClient
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

        /// <summary>
        /// Send DismissCurrentAlert request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/></returns>
        public async Task<StandardResponse<EmptyResponse>> DismissCurrentAlertAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.DismissCurrentAlert);

        /// <summary>
        /// Send GetRobotInfo request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{RobotInfo}"/></returns>
        public async Task<StandardResponse<RobotInfo>> GetRobotInfoAsync() => await SendCommandAsync<StandardResponse<RobotInfo>>(CommandType.GetRobotInfo);

        /// <summary>
        /// Send GetRobotState request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/></returns>
        public async Task<StateResponse<EmptyResponse>> GetRobotStateAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.GetRobotState);

        #endregion

        #region FindMe

        /// <summary>
        /// Send FindMe request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/></returns>
        public async Task<StandardResponse<EmptyResponse>> FindMeAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.FindMe);

        #endregion

        #region GeneralInfo

        /// <summary>
        /// Send GetGeneralInfo request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{GetGeneralInfo}"/>.</returns>
        public async Task<StandardResponse<GetGeneralInfo>> GetGeneralInfoAsync() => await SendCommandAsync<StandardResponse<GetGeneralInfo>>(CommandType.GetGeneralInfo);

        #endregion

        #region HouseCleaning and SpotCleaning

        /// <summary>
        /// Send StartCleaning request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        public async Task<StateResponse<EmptyResponse>> StartCleaningAsync(StartCleaningParameters parameters) => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.StartCleaning, parameters);

        /// <summary>
        /// Send StopCleaning request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        public async Task<StateResponse<EmptyResponse>> StopCleaningAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.StopCleaning);

        /// <summary>
        /// Send PauseCleaning request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        public async Task<StateResponse<EmptyResponse>> PauseCleaningAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.PauseCleaning);

        /// <summary>
        /// Send ResumeCleaning request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        public async Task<StateResponse<EmptyResponse>> ResumeCleaningAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.ResumeCleaning);

        /// <summary>
        /// Send SendToBase request.
        /// </summary>
        /// <returns>A <see cref="StateResponse{EmptyResponse}"/>.</returns>
        public async Task<StateResponse<EmptyResponse>> SendToBaseAsync() => await SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.SendToBase);

        #endregion

        #region LocalStats

        /// <summary>
        /// Send GetLocalStats request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{LocalStats}"/>.</returns>
        public async Task<StandardResponse<LocalStats>> GetLocalStatsAsync() => await SendCommandAsync<StandardResponse<LocalStats>>(CommandType.GetLocalStats);

        #endregion

        #region ManualCleaning

        /// <summary>
        /// Send GetRobotManualCleaningInfo request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{RobotManualCleaningInfo}"/>.</returns>
        public async Task<StandardResponse<RobotManualCleaningInfo>> GetRobotManualCleaningInfoAsync() => await SendCommandAsync<StandardResponse<RobotManualCleaningInfo>>(CommandType.GetRobotManualCleaningInfo);

        #endregion

        #region Maps

        /// <summary>
        /// Send GetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StandardResponse{MapBoundaries}"/>.</returns>
        public async Task<StandardResponse<MapBoundaries>> GetMapBoundariesAsync(GetMapBoundaries parameters) => await SendCommandAsync<StandardResponse<MapBoundaries>>(CommandType.GetMapBoundaries, parameters);

        /// <summary>
        /// Send SetMapBoundaries request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        public async Task<StandardResponse<EmptyResponse>> SetMapBoundariesAsync(SetMapBoundaries parameters) => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetMapBoundaries, parameters);

        /// <summary>
        /// Send StartPersistentMapExploration request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        public async Task<StandardResponse<EmptyResponse>> StartPersistentMapExplorationAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.StartPersistentMapExploration);

        #endregion

        #region Preferences

        /// <summary>
        /// Send GetPreferences request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{Preferences}"/>.</returns>
        public async Task<StandardResponse<Preferences>> GetPreferencesAdvanced1Async() => await SendCommandAsync<StandardResponse<Preferences>>(CommandType.GetPreferences);

        /// <summary>
        /// Send SetPreferences request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        public async Task<StandardResponse<EmptyResponse>> SetPreferencesAdvanced1Async(Preferences parameters) => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetPreferences, parameters);

        #endregion

        #region Schedule

        /// <summary>
        /// Send GetSchedule request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{Schedule}"/>.</returns>
        public async Task<StandardResponse<Schedule>> GetScheduleAsync() => await SendCommandAsync<StandardResponse<Schedule>>(CommandType.GetSchedule);

        /// <summary>
        /// Send SetSchedule request.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        public async Task<StandardResponse<EmptyResponse>> SetScheduleAsync(Schedule parameters) => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetSchedule, parameters);

        /// <summary>
        /// Send EnableSchedule request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        public async Task<StandardResponse<EmptyResponse>> EnableScheduleAsync() => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.EnableSchedule);

        /// <summary>
        /// Send DisableSchedule request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{Schedule}"/>.</returns>
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
