using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Neato.BeeHive.Protocol;
using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive
{
    /// <inheritdoc />
    public class BeeHiveClient : IBeeHiveClient
    {
        private const string _beehiveUrl = "https://beehive.neatocloud.com";
        private const string _acceptHeader = "application/vnd.neato.beehive.v1+json";

        private static readonly HttpClient _httpClient = new HttpClient { Timeout = Timeout.InfiniteTimeSpan };

        private readonly string _username;
        private readonly string _password;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeeHiveClient"/> class.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public BeeHiveClient(
            string username,
            string password)
        {
            _username = username ?? throw new ArgumentNullException(nameof(username));
            _password = password ?? throw new ArgumentNullException(nameof(password));
        }

        /// <inheritdoc />
        public async Task<MapsInformation> GetMapsAsync(string serialNumber, CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(new Uri(_beehiveUrl), $"users/me/robots/{serialNumber}/maps")
            };

            using (var response = await SendRequestAsync(requestMessage, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<MapsInformation>(await response.Content.ReadAsStringAsync());
            }
        }

        /// <inheritdoc />
        public async Task<IList<PersistentMapInformation>> GetPersistentMapsAsync(string serialNumber, CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(new Uri(_beehiveUrl), $"users/me/robots/{serialNumber}/persistent_maps")
            };

            using (var response = await SendRequestAsync(requestMessage, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<IList<PersistentMapInformation>>(await response.Content.ReadAsStringAsync());
            }
        }

        /// <inheritdoc />
        public async Task<IList<RobotInformation>> GetRobotsAsync(CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(new Uri(_beehiveUrl), "users/me/robots")
            };

            using (var response = await SendRequestAsync(requestMessage, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<IList<RobotInformation>>(await response.Content.ReadAsStringAsync());
            }
        }

        /// <inheritdoc />
        public async Task<UserInformation> GetUserAsync(CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(new Uri(_beehiveUrl), "users/me")
            };

            using (var response = await SendRequestAsync(requestMessage, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<UserInformation>(await response.Content.ReadAsStringAsync());
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
            var storedAuthToken = await AuthorizeAsync(cancellationToken);

            // Add headers
            requestMessage.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(_acceptHeader));
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", "token=" + storedAuthToken);

            return await _httpClient.SendAsync(requestMessage, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<string> AuthorizeAsync(CancellationToken cancellationToken = default)
        {
            using (RandomNumberGenerator csprng = new RNGCryptoServiceProvider())
            {
                byte[] rawByteArray = new byte[32];
                csprng.GetBytes(rawByteArray);

                var token = BitConverter.ToString(rawByteArray).Replace("-", string.Empty);

                var content = new SessionRequest
                {
                    Email = _username,
                    Password = _password,
                    Token = token
                };

                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(new Uri(_beehiveUrl), "sessions"),
                    Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
                };

                requestMessage.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(_acceptHeader));

                using (var response = await _httpClient.SendAsync(requestMessage, cancellationToken))
                {
                    response.EnsureSuccessStatusCode();

                    var responseContent = JsonConvert.DeserializeObject<SessionResponse>(await response.Content.ReadAsStringAsync());

                    return responseContent.AccessToken;
                }
            }
        }
    }
}
