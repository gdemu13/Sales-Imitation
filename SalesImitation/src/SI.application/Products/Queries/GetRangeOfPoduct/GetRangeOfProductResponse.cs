using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Products {
    public class GetRangeOfProductResponse {
        public IEnumerable<Product> Items { get; set; }
        public int Quantity { get; set; }
    }
}