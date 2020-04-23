using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Products {
    public class SaveNewProductHandler : IRequestHandler<SaveNewProductRequest, Result> {

        IProductRepository _productRepository;
        IPartnerRepository _partnerRepository;
        ICategoryRepository _categoryRepository;

        public SaveNewProductHandler (IProductRepository productRepository,
            IPartnerRepository partnerRepository,
            ICategoryRepository categoryRepository) {

            _productRepository = productRepository;
            _partnerRepository = partnerRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle (SaveNewProductRequest req, CancellationToken token) {
            //partner
            var p = await _partnerRepository.Get (req.Partner.ID);
            if (p == null)
                throw new Exception ("incorrect_partner");
            var partner = new ProductPartner (p.ID, p.Name);
            //price
            var price = new Money (req.Price);

            //product
            var product = new Product (req.ID, req.Name, req.Description, partner, price, req.Point, req.GroupID);

            //category
            if (req.Category != null) {
                var c = await _categoryRepository.Get (req.Category.ID);
                if (c == null)
                    throw new Exception ("incorrect_category");
                product.Category = new ProductCategory (c.ID, c.Name);
            }

            //images
            if (req.Images != null)
                foreach (var img in req.Images)
                    product.AddImage (img.ID, img.Url);

            return await _productRepository.Insert (product);
        }
    }
}