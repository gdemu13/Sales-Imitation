using System;

namespace SI.Domain.Entities {

    public class ProductImage : BaseEntity {

        public ProductImage(Guid id, string url) {
            ID = id;
            Url = url;
        }
        public string Url {get; set;}
    }
}