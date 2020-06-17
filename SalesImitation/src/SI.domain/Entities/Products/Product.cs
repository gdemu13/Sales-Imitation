using System;
using System.Collections.Generic;
using System.Linq;

namespace SI.Domain.Entities {

    public class Product : BaseEntity {

        public Product (Guid id, string name, string description,
            ProductPartner partner, Money price, int point, Guid groupID, string gift, bool isActive) {
            ID = id;
            Name = name;
            Description = description;
            Partner = partner;
            Price = price;
            Coin = point;
            ProductGroupID = groupID;
            IsActive = isActive;
            Gift = gift;

            _images = new List<ProductImage> ();
            _connectedProduct = new List<ConnectedProduct> ();

            if (partner == null) {
                throw new Exception ("partner_is_required");
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public Money Price { get; set; }

        private List<ProductImage> _images;
        public IReadOnlyList<ProductImage> Images => _images.AsReadOnly ();

        public void AddImage (Guid id, string url) {
            _images.Add (new ProductImage (id, url));
        }

        public void AddImage (ProductImage image) {
            _images.Add (image);
        }

        public void RemoveImage (Guid id) {
            _images.RemoveAll (i => i.ID == id);
        }

        private List<ConnectedProduct> _connectedProduct;
        public IReadOnlyList<ConnectedProduct> ConnectedProduct => _connectedProduct.AsReadOnly ();

        public void AddConnectedProduct (ConnectedProduct product) {
            _connectedProduct.Add (product);
        }

        public void RemoveConnectedProduct (Guid id) {
            _connectedProduct.RemoveAll (i => i.ID == id);
        }

        public ProductPartner Partner { get; set; }

        public ProductCategory Category { get; set; }

        public int Coin { get; set; }

        public bool IsActive { get; set; }

        public Guid ProductGroupID { get; set; }

        public string Gift { get; set; }
    }
}