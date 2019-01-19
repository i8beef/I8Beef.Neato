using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Neato.BeeHive.Models;
using I8Beef.Neato.BeeHive.Models.Auth;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive
{
    /// <summary>
    /// BeeHive client.
    /// </summary>
    public class BeeHiveClient
    {
        private const string _beehiveUrl = "https://beehive.neatocloud.com";
        private const string _acceptHeader = "application/vnd.neato.beehive.v1+json";
        private const string _tokenEndpoint = _beehiveUrl + "/oauth2/token";

        private readonly ILogger<BeeHiveClient> _log;
        private readonly string _serialNumber;
        private readonly UserAccessToken _token;
        private readonly HttpClient _httpClient;

        private Func<CancellationToken, Task<StoredAuthToken>> _getStoredAuthTokenFunc;
        private Func<StoredAuthToken, CancellationToken, Task> _setStoredAuthTokenFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeeHiveClient"/> class.
        /// </summary>
        /// <param name="logger">Logging instance.</param>
        /// <param name="httpClient">HttpClient.</param>
        /// <param name="serialNumber">Serial number.</param>
        /// <param name="secretKey">Secret key.</param>
        /// <param name="getStoredAuthTokenFunc">Lambda function responsible for retrieving current auth token data from permanent storage.</param>
        /// <param name="setStoredAuthTokenFunc">Lambda function responsible for saving current auth token data to permanent storage.</param>
        public BeeHiveClient(
            ILogger<BeeHiveClient> logger,
            HttpClient httpClient,
            string serialNumber,
            Func<CancellationToken, Task<StoredAuthToken>> getStoredAuthTokenFunc,
            Func<StoredAuthToken, CancellationToken, Task> setStoredAuthTokenFunc)
        {
            _log = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _serialNumber = serialNumber ?? throw new ArgumentNullException(nameof(serialNumber));

            _getStoredAuthTokenFunc = getStoredAuthTokenFunc ?? throw new ArgumentNullException(nameof(getStoredAuthTokenFunc));
            _setStoredAuthTokenFunc = setStoredAuthTokenFunc ?? throw new ArgumentNullException(nameof(setStoredAuthTokenFunc));
        }

        /// <summary>
        /// Send GetMaps request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="MapsInformation"/>.</returns>
        public async Task<MapsInformation> GetMapsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(new Uri(_beehiveUrl), $"users/me/robots/{_serialNumber}/maps")
            };

            var response = await SendRequestAsync(requestMessage, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _log.LogInformation("BeeHive {url} request sent", requestMessage.RequestUri);
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
                _log.LogWarning("BeeHive {url} request failed", requestMessage.RequestUri);
            }

            return JsonConvert.DeserializeObject<MapsInformation>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Send GetPersistentMaps request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="IList{PersistentMapInformation}"/>.</returns>
        public async Task<IList<PersistentMapInformation>> GetPersistentMapsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(new Uri(_beehiveUrl), $"users/me/robots/{_serialNumber}/persistent_maps")
            };

            var response = await SendRequestAsync(requestMessage, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _log.LogInformation("BeeHive {url} request sent", requestMessage.RequestUri);
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
                _log.LogWarning("BeeHive {url} request failed", requestMessage.RequestUri);
            }

            return JsonConvert.DeserializeObject<IList<PersistentMapInformation>>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Send GetRobots request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="IList{RobotInformation}"/>.</returns>
        public async Task<IList<RobotInformation>> GetRobotsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(new Uri(_beehiveUrl), "users/me/robots")
            };

            var response = await SendRequestAsync(requestMessage, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _log.LogInformation("BeeHive {url} request sent", requestMessage.RequestUri);
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
                _log.LogWarning("BeeHive {url} request failed", requestMessage.RequestUri);
            }

            return JsonConvert.DeserializeObject<IList<RobotInformation>>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Send GetUser request.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="UserInformation"/>.</returns>
        public async Task<UserInformation> GetUserAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(new Uri(_beehiveUrl), "users/me")
            };

            var response = await SendRequestAsync(requestMessage, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _log.LogInformation("BeeHive {url} request sent", requestMessage.RequestUri);
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
                _log.LogWarning("BeeHive {url} request failed", requestMessage.RequestUri);
            }

            return JsonConvert.DeserializeObject<UserInformation>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Sends a request.
        /// </summary>
        /// <param name="requestMessage">Request message.</param>
        /// <returns>An <see cref="HttpResponseMessage"/>.</returns>
        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            var storedAuthToken = await GetCurrentAuthTokenAsync(cancellationToken);

            // Add headers
            requestMessage.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(_acceptHeader));
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", storedAuthToken.AccessToken);

            return await _httpClient.SendAsync(requestMessage, cancellationToken);
        }

        /// <summary>
        /// Gets current auth token and handles refresh.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="StoredAuthToken"/>.</returns>
        private async Task<StoredAuthToken> GetCurrentAuthTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var storedAuthToken = await _getStoredAuthTokenFunc(cancellationToken);

            if (storedAuthToken == null)
            {
                throw new NullReferenceException("Auth token storage delegate failed to provide token.");
            }

            if (DateTime.Compare(DateTime.Now, storedAuthToken.TokenExpiration) >= 0)
            {
                var request = new RefreshTokenRequest
                {
                    GrantType = "refresh_token",
                    RefreshToken = storedAuthToken.RefreshToken
                };

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, _tokenEndpoint);
                requestMessage.Headers.ExpectContinue = false;
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request));

                var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Refresh token renewal failed.");

                var authToken = JsonConvert.DeserializeObject<UserAccessToken>(responseString);
                storedAuthToken = new StoredAuthToken
                {
                    AccessToken = authToken.AccessToken,
                    RefreshToken = authToken.RefreshToken,
                    TokenExpiration = DateTime.Now.AddSeconds(authToken.ExpiresIn)
                };

                await _setStoredAuthTokenFunc(storedAuthToken, cancellationToken);
            }

            return storedAuthToken;
        }
    }
}
