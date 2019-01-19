using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using I8Beef.Neato.Nucelo.Services.Common;
using I8Beef.Neato.Nucelo.Services.GeneralInfo;
using I8Beef.Neato.Nucelo.Services.HouseCleaning;
using I8Beef.Neato.Nucelo.Services.LocalStats;
using I8Beef.Neato.Nucelo.Services.ManualCleaning;
using I8Beef.Neato.Nucelo.Services.Maps;
using I8Beef.Neato.Nucelo.Services.Preferences;
using I8Beef.Neato.Nucelo.Services.Request;
using I8Beef.Neato.Nucelo.Services.Response;
using I8Beef.Neato.Nucelo.Services.Schedule;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo
{
    /// <summary>
    /// Nucleo client.
    /// </summary>
    public class NucleoClient
    {
        private const string _acceptHeader = "application/vnd.neato.nucleo.v1";
        private const string _nucleoUrl = "https://nucleo.neatocloud.com";
        private const string _nucleoMessageEndpoint = "vendors/neato/robots/{serialNumber}/messages";
        private const int _port = 4443;

        private readonly ILogger<NucleoClient> _log;
        private readonly string _serialNumber;
        private readonly string _secretKey;
        private readonly HttpClient _httpClient;

        private int _requestId = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="NucleoClient"/> class.
        /// </summary>
        /// <param name="logger">Logging instance.</param>
        /// <param name="httpClient">HttpClient.</param>
        /// <param name="serialNumber">Serial number.</param>
        /// <param name="secretKey">Secret key.</param>
        public NucleoClient(ILogger<NucleoClient> logger, HttpClient httpClient, string serialNumber, string secretKey)
        {
            _log = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _serialNumber = serialNumber ?? throw new ArgumentNullException(nameof(serialNumber));
            _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
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
        /// <returns>A <see cref="StandardResponse{MapBoundaries}"/>.</returns>
        public async Task<StandardResponse<MapBoundaries>> GetMapBoundariesAsync(GetMapBoundaries parameters) => await SendCommandAsync<StandardResponse<MapBoundaries>>(CommandType.GetMapBoundaries, parameters);

        /// <summary>
        /// Send SetMapBoundaries request.
        /// </summary>
        /// <returns>A <see cref="StandardResponse{EmptyResponse}"/>.</returns>
        public async Task<StandardResponse<EmptyResponse>> SetMapBoundariesAsync(SetMapBoundaries parameters) => await SendCommandAsync<StandardResponse<EmptyResponse>>(CommandType.SetMapBoundaries, parameters);

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
        /// <param name="request">Request to send.</param>
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

            var response = await SendRequestAsync(requestMessage);

            // Bump request id
            _requestId++;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _log.LogInformation("Nucleo request sent");
            }
            else
            {
                _log.LogWarning("Nucleo request failed");
            }

            return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Sends a request.
        /// </summary>
        /// <param name="requestMessage">Request message.</param>
        /// <returns>An <see cref="HttpResponseMessage"/>.</returns>
        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage)
        {
            var dateHeaderValue = DateTime.UtcNow;
            var body = requestMessage.Content;

            byte[] secretkey = Encoding.UTF8.GetBytes(_secretKey); ;
            using (HMACSHA256 hmac = new HMACSHA256(secretkey))
            {
                var authString = new StringBuilder();
                authString.AppendLine(_serialNumber.ToLower());
                authString.AppendLine(dateHeaderValue.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’"));
                authString.Append(body);

                var signature = hmac.ComputeHash(Encoding.UTF8.GetBytes(authString.ToString()));

                // Add headers
                requestMessage.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(_acceptHeader));
                requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("NEATOAPP", Encoding.UTF8.GetString(signature));
                requestMessage.Headers.Date = dateHeaderValue;

                return await _httpClient.SendAsync(requestMessage);
            }
        }
    }
}
