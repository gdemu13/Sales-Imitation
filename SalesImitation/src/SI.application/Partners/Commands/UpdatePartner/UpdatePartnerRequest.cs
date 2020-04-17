using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Partners {
    public class UpdatePartnerRequest : IRequest<Result> {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public UpdateAddress Address { get; set; }

        public UpdateContactInfo Contact { get; set; }

        public UpdateContactPerson ContactPerson { get; set; }

        public string WebSite { get; set; }

        public class UpdateContactInfo {
            public string Number { get; set; }
            public string Email { get; set; }
        }

        public class UpdateContactPerson {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Number { get; set; }
            public string Email { get; set; }
        }

        public class UpdateAddress {
            public string Street { get; set; }
        }
    }

}