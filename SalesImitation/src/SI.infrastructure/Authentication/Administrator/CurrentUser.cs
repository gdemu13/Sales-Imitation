using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using SI.Domin.Abstractions.Authentication;

namespace SI.Infrastructure.Authentication.Administrator
{
    public class CurrentUser : ICurrentUser
    {
        IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext.User != null && _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                ID = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                DisplayName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                IsAuthenticated = true;
            }
        }

        public bool IsAuthenticated { get; private set; }
        public Guid? ID { get; private set; }
        public string DisplayName { get; private set; }
        public async Task SignIn(Guid id, string displayName)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, displayName),
            };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);


            await _httpContextAccessor.HttpContext.SignInAsync(
                 CookieAuthenticationDefaults.AuthenticationScheme,
                 principal,
                 new AuthenticationProperties { IsPersistent = false });

        }
        public async Task SignOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(
               CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}