using Data.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Services;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace WebAPI.Helper
{   
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        #region Property
        readonly IUsermasterService _userService;
        #endregion

        #region Constructor
        public BasicAuthenticationHandler(IUsermasterService userService,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }
        #endregion

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            UsermasterVM user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                string username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();

                UserLoginRequest loginRequest = new UserLoginRequest { UserName = username, Password = password };
                user = _userService.Authenticate(loginRequest);

                if (user == null)
                    throw new ArgumentException("Invalid credentials");
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);           

            return AuthenticateResult.Success(ticket);
        }

    }



}
