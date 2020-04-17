using System;

namespace SI.Domain.Entities {
    public class Category : BaseEntity {
        public Category(Guid id, string name) {
            ID = id;
            Name = name;
        }

        public string Name {get; set;}
        public bool IsActive {get; set;}
    }
}