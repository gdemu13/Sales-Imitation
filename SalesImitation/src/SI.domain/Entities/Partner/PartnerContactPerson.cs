namespace SI.Domain.Entities {

    public class PartnerContactPerson {

        public PartnerContactPerson(string firstname, string lastname, string number, string email) {
            FirstName = firstname;
            LastName = lastname;
            Number = number;
            Email = email;
        }
        public string FirstName {get; }
        public string LastName {get; }
        public string Number {get; }
        public string Email {get; }
    }
}