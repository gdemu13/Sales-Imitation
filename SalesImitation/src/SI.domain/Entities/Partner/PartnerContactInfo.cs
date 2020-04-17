
namespace SI.Domain.Entities {

    public class PartnerContactInfo {

        public PartnerContactInfo(string number, string email) {
            Number = number;
            Email = email;
        }
        public string Number {get; set;}
        public string Email {get; set;}
    }
}