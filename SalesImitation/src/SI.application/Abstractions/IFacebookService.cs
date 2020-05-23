using System;
using System.Threading.Tasks;

namespace SI.Application.Abstractions
{
    public interface IFacebookService
    {
        Task<FacebookGetUserResponse> GetUser(string accessToken, string userID);
    }

    public class FacebookGetUserResponse
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public FacebookError Error { get; set; }
    }

    public class FacebookError
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public int Code { get; set; }
    }
}