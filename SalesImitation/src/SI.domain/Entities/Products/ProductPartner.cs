using System;

namespace SI.Domain.Entities {

    public class ProductPartner : BaseEntity {

        public ProductPartner (Guid id, string name) {
            ID = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}