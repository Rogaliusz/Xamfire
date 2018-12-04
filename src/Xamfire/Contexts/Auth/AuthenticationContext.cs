using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamfire.Exceptions;
using Xamfire.Exceptions.Auth;
using Xamfire.Json.Serializer.Document;
using Xamfire.Network.Requests;
using Xamfire.Network.Responses;
using Xamfire.Network.Service;
using Xamfire.Settings;

namespace Xamfire.Contexts.Auth
{
    public class AuthenticationContext : IAuthenticationContext
    {
        private const string REGISTER_URL = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key={0}";
        private const string LOGIN_URL = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key={0}";

        private readonly IFirebaseSettings _settings;
        private readonly INetworkService _networkService;
        private readonly IJsonDocumentSerializer _jsonSerializer;

        public AuthenticationContext(IFirebaseSettings settings, INetworkService networkService, IJsonDocumentSerializer jsonSerializer)
        {
            _settings = settings;
            _networkService = networkService;
            _jsonSerializer = jsonSerializer;
        }

        public async Task LoginUserAsync(string email, string password)
        {
            var registerRequest = new LoginRequest(email, password, true);
            var response = await _networkService.PostAsync<LoginResponse>(string.Format(LOGIN_URL, _settings.ApiKey), registerRequest);

            if (response.StatusCode != 200)
            {
                throw new InvalidCredentialsException(response.Error?.Message);
            }

            _settings.UserToken = response.IdToken;
            _settings.UserRefreshToken = response.RefreshToken;
        }

        public async Task RegisterUserAsync(string email, string password)
        {
            var registerRequest = new RegisterRequest(email, password, true);
            var response = await _networkService.PostAsync<RegisterResponse>(string.Format(REGISTER_URL, _settings.ApiKey), registerRequest);

            if (response.StatusCode != 200)
            {
                throw new FailRegisterException(response.Error?.Message);
            }
        }
    }
}
