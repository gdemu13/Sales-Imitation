using System;
using MediatR;
using SI.Common.Models;
using System.Collections.Generic;

namespace SI.Application.Products {
    public class SaveNewProductRequest : IRequest<Result> {
        public Guid? GroupID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SavePartner Partner { get; set; }

        public decimal Price { get; set; }

        public int Point { get; set; }
        public bool IsActive { get; set; }

        public SaveCategory Category { get; set; }

        public IEnumerable<SaveProductImage> Images { get; set; }

        public class SavePartner {
            public Guid ID { get; set; }
        }

        public class SaveCategory {
            public Guid ID { get; set; }
        }

        public class SaveProductImage {
            public string Url { get; set; }
        }
    }
}