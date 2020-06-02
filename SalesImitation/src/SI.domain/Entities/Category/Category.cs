using System;

namespace SI.Domain.Entities {
    public class Category : BaseEntity {
        public Category(Guid id, string name, string color, string iconUrl) {
            ID = id;
            Name = name;
            Color = color;
            IconUrl = iconUrl;
        }

        public string Name {get; set;}

        public string Color { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive {get; set;}
    }
}