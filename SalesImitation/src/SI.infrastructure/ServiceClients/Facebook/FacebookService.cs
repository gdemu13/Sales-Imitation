using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SI.Application.Abstractions;

namespace SI.Infrastructure.ServiceClients.Facebook
{
    public class FacebookService : IFacebookService
    {
        private readonly IHttpClientFactory clientFactory;

        public FacebookService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<FacebookGetUserResponse> GetUser(string accessToken, string userID)
        {
            HttpClient client = clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://graph.facebook.com/");
            var response = await client.GetAsync($"{userID}?fields=id,name,birthday,email&access_token={accessToken}");
            string jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize
                                <FacebookGetUserResponseDTO>(jsonData);
            DateTime.TryParseExact(data.birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out var bd);
            return new FacebookGetUserResponse
            {
                BirthDate = bd,
                Email = data.email,
                Error = data.error == null ? null : new FacebookError
                {
                    Code = data.error.code,
                    Type = data.error.type,
                    Message = data.error.message
                },
                ID = data.id,
                Name = data.name
            };
        }

        public class FacebookGetUserResponseDTO
        {
            public string id { get; set; }
            public string name { get; set; }
            public string birthday { get; set; }
            public string email { get; set; }
            public FacebookErrorDTO error { get; set; }
        }

        public class FacebookErrorDTO
        {
            public string message { get; set; }
            public string type { get; set; }
            public int code { get; set; }
        }
    }
}