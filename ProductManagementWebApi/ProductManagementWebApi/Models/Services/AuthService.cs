using ProductManagementWebApi.Models.Interface;

namespace ProductManagementWebApi.Models.Services
{
    public class AuthService : IAuthService
    {
        readonly ITokenService tokenService;
        readonly IUserService userService;
        public AuthService(ITokenService _tokenService,IUserService userService)
        {
            this.tokenService = _tokenService;
            this.userService= userService;
        }

        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {

            UserLoginResponse response = new();

            if(String.IsNullOrEmpty(request.Username) || String.IsNullOrEmpty(request.Password) ) {
                
                throw new ArgumentNullException(nameof(request));
            }
            var users= await userService.GetAllUserAsync();
            var usr= users.FirstOrDefault(us=>us.UserName == request.Username && us.Password==request.Password);

            if (usr!=null)
            {
                var generateTokenInformation = await tokenService.GenerateTokenAsync(new GenerateTokenRequest
                {
                    Username = request.Username,

                });
                response.AccessTokenExpireDate = generateTokenInformation.TokenExpireDate;
                response.AuthenticateResult = true;
                response.AuthToken = generateTokenInformation.Token;
                response.username = usr.UserName;
            }
            return response;

        }
    }
}
