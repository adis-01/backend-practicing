using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using practice.Services;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace practice.Repo
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public IKorisnikService _service;
        public BasicAuthenticationHandler(IKorisnikService service,IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _service = service;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No headers");
            }
            var headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialsByte = Convert.FromBase64String(headerValue.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialsByte).Split(":");

            var username = credentials[0];
            var password = credentials[1];

            var korisnik = await _service.Login(username, password);

            if (korisnik == null)
                return AuthenticateResult.Fail("Username or password incorrect");
            else
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,korisnik.FirstName),
                    new Claim(ClaimTypes.NameIdentifier,korisnik.KorisnickoIme)
                };
                foreach (var uloga in korisnik.KorisniciUloges)
                {
                    claims.Add(new Claim(ClaimTypes.Role, uloga.Uloga.NazivUloge));
                }
                var identity = new ClaimsIdentity(claims,Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal,Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
        }
    }
}
