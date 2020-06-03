using System;

namespace SI.Application.Players
{
    public class LoginWithFacebookResponse
    {
        public bool RegistrationNeeded { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string AccessToken { get; set; }
        public string UserID { get; set; }
    }
}