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
        public Task<StandardResponse<EmptyResponse>> DismissCurrentAlertAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.DismissCurrentAlert, null, cancellationToken);

        /// <inheritdoc />
        public Task<StandardResponse<RobotInfo>> GetRobotInfoAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<RobotInfo>>(CommandType.GetRobotInfo, null, cancellationToken);

        /// <inheritdoc />
        public Task<StateResponse<EmptyResponse>> GetRobotStateAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.GetRobotState, null, cancellationToken);

        #endregion

        #region FindMe

        /// <inheritdoc />
        public Task<StandardResponse<EmptyResponse>> FindMeAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.FindMe, null, cancellationToken);

        #endregion

        #region GeneralInfo

        /// <inheritdoc />
        public Task<StandardResponse<GetGeneralInfo>> GetGeneralInfoAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<GetGeneralInfo>>(CommandType.GetGeneralInfo, null, cancellationToken);

        #endregion

        #region HouseCleaning and SpotCleaning

        /// <inheritdoc />
        public Task<StateResponse<EmptyResponse>> StartCleaningAsync(StartCleaningParameters parameters, CancellationToken cancellationToken = default) => SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.StartCleaning, parameters, cancellationToken);

        /// <inheritdoc />
        public Task<StateResponse<EmptyResponse>> StopCleaningAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.StopCleaning, null, cancellationToken);

        /// <inheritdoc />
        public Task<StateResponse<EmptyResponse>> PauseCleaningAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.PauseCleaning, null, cancellationToken);

        /// <inheritdoc />
        public Task<StateResponse<EmptyResponse>> ResumeCleaningAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.ResumeCleaning, null, cancellationToken);

        /// <inheritdoc />
        public Task<StateResponse<EmptyResponse>> SendToBaseAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StateResponse<EmptyResponse>>(CommandType.SendToBase, null, cancellationToken);

        #endregion

        #region LocalStats

        /// <inheritdoc />
        public Task<StandardResponse<LocalStats>> GetLocalStatsAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<LocalStats>>(CommandType.GetLocalStats, null, cancellationToken);

        #endregion

        #region ManualCleaning

        /// <inheritdoc />
        public Task<StandardResponse<RobotManualCleaningInfo>> GetRobotManualCleaningInfoAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<RobotManualCleaningInfo>>(CommandType.GetRobotManualCleaningInfo, null, cancellationToken);

        #endregion

        #region Maps

        /// <inheritdoc />
        public Task<StandardResponse<MapBoundaries>> GetMapBoundariesAsync(GetMapBoundaries parameters, CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<MapBoundaries>>(CommandType.GetMapBoundaries, parameters, cancellationToken);

        /// <inheritdoc />
        public Task<StandardResponse<EmptyResponse>> SetMapBoundariesAsync(SetMapBoundaries parameters, CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetMapBoundaries, parameters, cancellationToken);

        /// <inheritdoc />
        public Task<StandardResponse<EmptyResponse>> StartPersistentMapExplorationAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.StartPersistentMapExploration, null, cancellationToken);

        #endregion

        #region Preferences

        /// <inheritdoc />
        public Task<StandardResponse<Preferences>> GetPreferencesAdvanced1Async(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<Preferences>>(CommandType.GetPreferences, null, cancellationToken);

        /// <inheritdoc />
        public Task<StandardResponse<EmptyResponse>> SetPreferencesAdvanced1Async(Preferences parameters, CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetPreferences, parameters, cancellationToken);

        #endregion

        #region Schedule

        /// <inheritdoc />
        public Task<StandardResponse<Schedule>> GetScheduleAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<Schedule>>(CommandType.GetSchedule, null, cancellationToken);

        /// <inheritdoc />
        public Task<StandardResponse<EmptyResponse>> SetScheduleAsync(Schedule parameters, CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetSchedule, parameters, cancellationToken);

        /// <inheritdoc />
        public Task<StandardResponse<EmptyResponse>> EnableScheduleAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.EnableSchedule, null, cancellationToken);

        /// <inheritdoc />
        public Task<StandardResponse<EmptyResponse>> DisableScheduleAsync(CancellationToken cancellationToken = default) => SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.DisableSchedule, null, cancellationToken);

        #endregion

        /// <summary>
        /// Send a standard command.
        /// </summary>
        /// <typeparam name="TResponse">Type of response message.</typeparam>
        /// <param name="command">Command to send.</param>
        /// <param name="parameters">Parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        private async Task<TResponse> SendCommandAsync<TResponse>(CommandType command, object parameters = null, CancellationToken cancellationToken = default)
        {
            var request = new Request(_requestId, command, parameters);

            var serializedContent = JsonConvert.SerializeObject(request);
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(new Uri(_nucleoUrl), _nucleoMessageEndpoint.Replace("{serialNumber}", _serialNumber)),
                Content = new StringContent(serializedContent, Encoding.UTF8, "application/json")
            };

            using (var response = await SendRequestAsync(requestMessage, cancellationToken).ConfigureAwait(false))
            {
                // Bump request id
                _requestId++;

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
        }

        /// <summary>
        /// Sends a request.
        /// </summary>
        /// <param name="requestMessage">Request message.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An <see cref="HttpResponseMessage"/>.</returns>
        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            var dateHeaderValue = DateTime.UtcNow.ToString("ddd, dd MMM yyy HH:mm:ss 'GMT'");
            var body = await requestMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            byte[] secretkey = Encoding.UTF8.GetBytes(_secretKey);
            using (HMACSHA256 hmac = new HMACSHA256(secretkey))
            {
                var authString = string.Join("\n", _serialNumber.ToLower(), dateHeaderValue, body);

                var signature = hmac.ComputeHash(Encoding.UTF8.GetBytes(authString));

                // Add headers
                requestMessage.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(_acceptHeader));
                requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("NEATOAPP", BitConverter.ToString(signature).Replace("-", string.Empty).ToLower());
                requestMessage.Headers.Add("X-Date", dateHeaderValue);

                return await _httpClient.SendAsync(requestMessage, cancellationToken)
                    .ConfigureAwait(false);
            }
        }
    }
}
