using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Products {
    public class UpdateProductRequest : IRequest<Result> {
        public Guid ID { get; set; }

        public Guid GroupID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UpdatePartner Partner { get; set; }

        public decimal Price { get; set; }

        public int Point { get; set; }

        public UpdateCategory Category { get; set; }

        public class UpdatePartner {
            public Guid ID { get; set; }
        }

        public class UpdateCategory {
            public Guid ID { get; set; }
        }
    }

}