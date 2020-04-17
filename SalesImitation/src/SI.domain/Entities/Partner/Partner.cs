using System;

namespace SI.Domain.Entities {
    public class Partner : BaseEntity {
        public Partner(Guid id, string name) {
            ID = id;
            Name = name;
        }

        public string Name {get; set;}

        public PartnerLogo Logo {get; set;}

        public PartnerAddress Address {get; set;}

        public PartnerContactInfo ContactInfo {get; set;}

        public PartnerContactPerson ContactPerson {get; set;}

        public string WebSite {get; set;}

        public bool IsActive {get; set;}
    }
}