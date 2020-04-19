using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Infrastructure.DAL.Repository {
    public class ProductRepository : IProductRepository {
        private readonly IConfiguration _config;

        public ProductRepository (IConfiguration config) {
            _config = config;
        }

        private IDbConnection Connection {
            get {
                return new SqlConnection (_config.GetConnectionString ("siconnectionstring"));
            }
        }

        public async Task<Product> Get (Guid id) {
            // string sql = "SELECT * From Products Where ID = @ID;";
            Product product = null;
            // using (var connection = Connection) {
            //     var res = await connection.QueryFirstOrDefaultAsync<ProductModel> (sql,new {ID =id } );
            //     if(res != null) {
            //         product = new Product(res.ID, res.Name);
            //     }
            // }
            return product;
        }

        public async Task<IEnumerable<Product>> GetRange (int skip, int take) {
            string sql = @"SELECT
                                    prod.*, part.Name as PartnerName, img.ID as ImageID,
                                    cat.Name as CategoryName, img.Url as ImageUrl
                        FROM		Products prod
                        LEFT JOIN	Partners part
                            ON		prod.PartnerID = part.ID
                        LEFT JOIN	Categories cat
                            ON		prod.CategoryID = cat.ID
                        LEFT JOIN	ProductImages img
                            ON		img.ProductID = prod.ID
                        ORDER BY	Ordering
                        OFFSET		@Skip ROWS
                        FETCH NEXT	@Take ROWS ONLY;";

            List<Product> products = null;
            using (var connection = Connection) {
                var productsResult = await connection.QueryAsync (sql, new {
                    @Skip = skip,
                        @Take = take,
                });
                if (productsResult != null) {

                    var res = from prod in productsResult
                    let partner = new ProductPartner (prod.PartnerID, prod.PartnerName)
                    let price = new Money (prod.Price)
                    let category = prod.CategoryID == null ? null : new ProductCategory (prod.CategoryID, prod.CategoryName)
                    group prod
                    by new Product (prod.ID, prod.Name, prod.Description, partner, price, prod.Point) { Category = category } into p
                    select p;

                    products = new List<Product> ();
                    foreach (var prod in res) {
                        Product pr = prod.Key;
                        foreach (var img in prod) {
                            Console.WriteLine (img.ImageID == null ? Guid.Empty : img.ImageID);
                            if (img != null && img.ImageID != null)
                                pr.AddImage (img.ImageID, img.ImageUrl);
                        }
                        products.Add (pr);
                    }
                }
            }
            return products;
        }

        private class ProductModel {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public string LogoUrl { get; set; }
            public string Street { get; set; }
            public string Number { get; set; }
            public string Email { get; set; }
            public string ContactPersonFirstName { get; set; }
            public string ContactPersonLastName { get; set; }
            public string ContactPersonNumber { get; set; }
            public string ContactPersonEmail { get; set; }
            public string WebSite { get; set; }
            public bool IsActive { get; set; }
        }

        public async Task<Result> Insert (Product product) {

            string sqlProduct = @"INSERT INTO Products
            (ID, Name, Description, Price, Point, PartnerID, CategoryID, IsActive)
            Values
            (@ID, @Name, @Description, @Price, @Point, @PartnerID, @CategoryID, @IsActive);";

            string sqlProductImages = @"INSERT INTO ProductImages
            (ID, Url, ProductID)
            Values
            (@ID, @Url, @ProductID);";

            using (var connection = Connection) {
                connection.Open ();
                using (var transaction = connection.BeginTransaction ()) {
                    try {
                        var affectedRows = await connection.ExecuteAsync (sqlProduct,
                            new {
                                ID = product.ID,
                                    Name = product.Name,
                                    Description = product.Description,
                                    Price = product.Price.Amount,
                                    Point = product.Point,
                                    PartnerID = product.Partner.ID,
                                    CategoryID = product.Category?.ID,
                                    IsActive = product.IsActive
                            }, transaction);
                        if (product.Images != null && product.Images.Count () > 0) {
                            affectedRows = await connection.ExecuteAsync (sqlProductImages,
                                product.Images.Select (i => new {
                                    ID = product.ID,
                                        Url = product.Name,
                                        ProductID = product.ID,
                                }), transaction);
                        }

                        transaction.Commit ();
                    } catch (Exception ex) {
                        transaction.Rollback ();
                    }
                }
            }

            // using (var connection = Connection) {
            //     var affectedRows = await connection.ExecuteAsync (sql,
            //         new {
            //             ID = product.ID,
            //                 Name = product.Name,
            //                 LogoUrl = product.Logo.Url,
            //                 Street = product.Address?.Street,
            //                 Number = product.ContactInfo?.Number,
            //                 Email = product.ContactInfo?.Email,
            //                 ContactPersonFirstName = product.ContactPerson?.FirstName,
            //                 ContactPersonLastName = product.ContactPerson?.LastName,
            //                 ContactPersonNumber = product.ContactPerson?.Number,
            //                 ContactPersonEmail = product.ContactPerson?.Email,
            //                 WebSite = product.WebSite,
            //                 IsActive = product.IsActive
            //         });
            // }

            return await Task.FromResult (new Result ());
        }

        public async Task<Result> Update (Guid id, Product product) {

            // string sql = "UPDATE Categories SET Name = @Name where ID = @ID;";

            // using (var connection = Connection) {
            //     var affectedRows = await connection.ExecuteAsync (sql,
            //         new {
            //             ID = id,
            //                 Name = name,
            //         });
            // }

            return await Task.FromResult (new Result ());
        }

        public async Task<Result> SetIsActive (Guid id, bool isActive) {

            // string sql = "UPDATE Categories SET IsActive = @IsActive where ID = @ID;";

            // using (var connection = Connection) {
            //     var affectedRows = await connection.ExecuteAsync (sql,
            //         new {
            //             ID = id,
            //                 IsActive = isActive,
            //         });
            // }

            return await Task.FromResult (new Result ());
        }
    }
}