using System;
using System.Collections.Generic;
using System.Linq;

namespace SI.Domain.Entities {

    public class Product : BaseEntity {

        public Product (Guid id, string name, string description, ProductPartner partner, Money price, int point) {
            ID = id;
            Name = name;
            Description = description;
            Partner = partner;
            Price = price;
            Point = point;
            _images = new List<ProductImage> ();

            if (partner == null) {
                throw new Exception ("partner_required");
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public Money Price { get; set; }

        private List<ProductImage> _images;
        public IEnumerable<ProductImage> Images => _images.AsReadOnly ();

        public void AddImage (Guid id, string url) {
            _images.Add (new ProductImage (id, url));
        }

        public void AddImage (ProductImage image) {
            _images.Add (image);
        }

        public void RemoveImage (Guid id) {
            _images.RemoveAll (i => i.ID == id);
        }

        public ProductPartner Partner { get; set; }

        public ProductCategory Category { get; set; }

        public int Point { get; set; }

        public bool IsActive { get; set; }
    }
}