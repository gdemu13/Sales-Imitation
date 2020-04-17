using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Partners {
    public class SaveNewPartnerRequest : IRequest<Result> {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public SaveAddress Address { get; set; }

        public SaveContactInfo Contact { get; set; }

        public SaveContactPerson ContactPerson { get; set; }

        public string WebSite { get; set; }
    }

    public class SaveContactInfo {
        public string Number { get; set; }
        public string Email { get; set; }
    }

    public class SaveContactPerson {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }

    public class SaveAddress {
        public string Street { get; set; }
    }
}