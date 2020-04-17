using System;

namespace SI.Domain.Entities {

    public class ProductCategory : BaseEntity {

        public ProductCategory(Guid id, string name) {
            ID = id;
            Name = name;
        }
        public string Name {get; set;}
    }
}