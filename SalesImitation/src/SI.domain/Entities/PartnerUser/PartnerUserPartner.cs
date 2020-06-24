using System;

namespace SI.Domain.Entities
{
    public class PartnerUserPartner
    {
        public PartnerUserPartner(Guid ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public Guid ID { get; }
        public string Name { get; }
    }
}