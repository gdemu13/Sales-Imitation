using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Partners {
    public class GetangeOfPartnerResponse {
        public IEnumerable<Partner> Items { get; set; }
        public int Quantity { get; set; }
    }
}