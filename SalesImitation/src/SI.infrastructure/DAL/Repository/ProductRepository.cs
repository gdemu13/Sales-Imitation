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

namespace SI.Infrastructure.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _config;

        public ProductRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("siconnectionstring"));
            }
        }

        // public async Task<Product> Get (Guid id) {
        //     Product product = null;
        //     string sql = @"SELECT
        //                             prod.*, part.Name as PartnerName, at.Name as CategoryName,
        //                             img.*
        //                 FROM		Products prod
        //                 LEFT JOIN	Partners part
        //                     ON		prod.PartnerID = part.ID
        //                 LEFT JOIN	Categories cat
        //                     ON		prod.CategoryID = cat.ID
        //                 LEFT JOIN	ProductImages img
        //                     ON		img.ProductID = prod.ID
        //                 WHERE	    prod.ID = @ID;";

        //     using (var connection = Connection) {
        //         var productsResult = await connection.QueryAsync (sql, new {
        //             @ID = id,
        //         });
        //         if (productsResult != null) {

        //             var res = from prod in productsResult
        //             let partner = new ProductPartner (prod.PartnerID, prod.PartnerName)
        //             let price = new Money (prod.Price)
        //             let category = prod.CategoryID == null ? null : new ProductCategory (prod.CategoryID, prod.CategoryName)
        //             group prod
        //             by new Product (prod.ID, prod.Name, prod.Description,
        //                 partner, price, prod.Point, prod.ProductGroupID) { Category = category } into p
        //             select p;

        //             foreach (var prod in res) {
        //                 Product pr = prod.Key;
        //                 foreach (var img in prod) {
        //                     if (img != null && img.ImageID != null)
        //                         pr.AddImage (img.ImageID, img.ImageUrl);
        //                 }
        //                 product = pr;
        //             }
        //         }
        //     }
        //     return product;
        // }

        public async Task<Product> Get(Guid id)
        {
            Product product = null;
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
                        WHERE	    prod.ID = @ID;";

            using (var connection = Connection)
            {
                var productsResult = await connection.QueryAsync(sql, new
                {
                    @ID = id,
                });
                if (productsResult != null)
                {

                    var res = from prod in productsResult
                              let partner = new ProductPartner(prod.PartnerID, prod.PartnerName)
                              let price = new Money(prod.Price)
                              let category = prod.CategoryID == null ? null : new ProductCategory(prod.CategoryID, prod.CategoryName)
                              group prod
                              by new Product(prod.ID, prod.Name, prod.Description,
                                  partner, price, prod.Point, prod.ProductGroupID, prod.Gift, prod.IsActive)
                              { Category = category } into p
                              select p;

                    foreach (var prod in res)
                    {
                        Product pr = prod.Key;
                        foreach (var img in prod)
                        {
                            if (img != null && img.ImageID != null)
                                pr.AddImage(img.ImageID, img.ImageUrl);
                        }
                        product = pr;
                    }
                }
            }
            var connectedProducts = await GetConnectedProducts(product.ProductGroupID);
            connectedProducts = connectedProducts.Where(p => p.ID != product.ID);

            foreach (var cp in connectedProducts)
            {
                product.AddConnectedProduct(cp);
            }
            return product;
        }

        public async Task<IEnumerable<ConnectedProduct>> GetConnectedProducts(Guid groupID)
        {
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
                        WHERE       prod.ProductGroupID = @GroupID
                        ORDER BY	Ordering;";

            List<ConnectedProduct> products = null;
            using (var connection = Connection)
            {
                var productsResult = await connection.QueryAsync(sql, new
                {
                    @GroupID = groupID,
                });
                if (productsResult != null)
                {

                    var res = from prod in productsResult
                              let partner = new ProductPartner(prod.PartnerID, prod.PartnerName)
                              let price = new Money(prod.Price)
                              let category = prod.CategoryID == null ? null : new ProductCategory(prod.CategoryID, prod.CategoryName)
                              group prod
                              by new ConnectedProduct(prod.ID, prod.Name, prod.Description, partner, price, prod.Point, prod.ProductGroupID, prod.Gift) { Category = category } into p
                              select p;

                    products = new List<ConnectedProduct>();
                    foreach (var prod in res)
                    {
                        var pr = prod.Key;
                        foreach (var img in prod)
                        {
                            if (img != null && img.ImageID != null)
                                pr.AddImage(img.ImageID, img.ImageUrl);
                        }
                        products.Add(pr);
                    }
                }
            }

            return products;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories(decimal fromPrice, decimal toPrice)
        {
            string sql = @"select
                        cat.ID, cat.Name
                        from Products prod
                        left join Categories cat
                        on prod.CategoryID = cat.ID
                        where prod.Price >= @From and prod.Price <= @To and prod.IsActive = 1 and cat.IsActive = 1
                        group by cat.ID, cat.Name;";

            IEnumerable<ProductCategory> productCategories = null;
            using (var connection = Connection)
            {
                var productsResult = await connection.QueryAsync(sql, new
                {
                    @From = fromPrice,
                    @To = toPrice,
                });

                if (productsResult != null)
                    productCategories = productsResult.Select(pc => new ProductCategory(pc.ID, pc.name));
            }
            return productCategories;
        }
        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesWithConnectedProducts(decimal fromPrice, decimal toPrice, int minConnections)
        {
            string sql = @"select
                        cat.ID, cat.Name
                        from Products prod
                        left join Categories cat
                        on prod.CategoryID = cat.ID
                        where prod.Price >= @From and prod.Price <= @To and prod.IsActive = 1 and cat.IsActive = 1
                        group by cat.ID, cat.Name
                        having count(prod.ProductGroupID) > @MinConnections;";

            IEnumerable<ProductCategory> productCategories = null;
            using (var connection = Connection)
            {
                var productsResult = await connection.QueryAsync(sql, new
                {
                    From = fromPrice,
                    To = toPrice,
                    MinConnections = minConnections,
                });

                if (productsResult != null)
                    productCategories = productsResult.Select(pc => new ProductCategory(pc.ID, pc.name));
            }
            return productCategories;
        }
        public async Task<IEnumerable<Product>> GetRange(int skip, int take)
        {
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
            using (var connection = Connection)
            {
                var productsResult = await connection.QueryAsync(sql, new
                {
                    @Skip = skip,
                    @Take = take,
                });
                if (productsResult != null)
                {

                    var res = from prod in productsResult
                              let partner = new ProductPartner(prod.PartnerID, prod.PartnerName)
                              let price = new Money(prod.Price)
                              let category = prod.CategoryID == null ? null : new ProductCategory(prod.CategoryID, prod.CategoryName)
                              group prod
                              by new Product(prod.ID, prod.Name, prod.Description, partner, price, prod.Point, prod.ProductGroupID, prod.Gift, prod.IsActive) { Category = category } into p
                              select p;

                    products = new List<Product>();
                    foreach (var prod in res)
                    {
                        Product pr = prod.Key;
                        foreach (var img in prod)
                        {
                            if (img != null && img.ImageID != null)
                                pr.AddImage(img.ImageID, img.ImageUrl);
                        }
                        products.Add(pr);
                    }
                }
            }
            //make connections by groupid
            foreach (var prod in products)
            {
                var connections = products.Where(p => p.ProductGroupID == prod.ProductGroupID && p.ID != prod.ID)
                    .Select(p =>
                    {
                        var cp = new ConnectedProduct(p.ID, p.Name, p.Description, p.Partner, p.Price, p.Coin, p.ProductGroupID, p.Gift) { Category = p.Category };
                        foreach (var i in p.Images)
                        {
                            cp.AddImage(i);
                        }
                        return cp;
                    });
                foreach (var con in connections)
                {
                    prod.AddConnectedProduct(con);
                }
            }
            return products;
        }

        private class ProductModel
        {
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

        public async Task<Result> Insert(Product product)
        {

            string sqlProduct = @"INSERT INTO Products
            (ID, Name, Description, Price, Point, PartnerID, CategoryID, ProductGroupID, Gift, IsActive)
            Values
            (@ID, @Name, @Description, @Price, @Point, @PartnerID, @CategoryID, @ProductGroupID , @Gift, @IsActive);";

            string sqlProductImages = @"INSERT INTO ProductImages
            (ID, Url, ProductID)
            Values
            (@ID, @Url, @ProductID);";

            using (var connection = Connection)
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRows = await connection.ExecuteAsync(sqlProduct,
                            new
                            {
                                ID = product.ID,
                                Name = product.Name,
                                Description = product.Description,
                                Price = product.Price.Amount,
                                Point = product.Coin,
                                PartnerID = product.Partner.ID,
                                CategoryID = product.Category?.ID,
                                ProductGroupID = product.ProductGroupID,
                                IsActive = product.IsActive,
                                Gift = product.Gift,
                            }, transaction);
                        if (product.Images != null && product.Images.Count() > 0)
                        {
                            affectedRows = await connection.ExecuteAsync(sqlProductImages,
                                product.Images.Select(i => new
                                {
                                    ID = i.ID,
                                    Url = i.Url,
                                    ProductID = product.ID,
                                }), transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> Update(Guid id, Product product)
        {
            string sqlProduct = @"UPDATE Products SET
            Name = @Name,
            Description = @Description,
            Price = @Price,
            Point = @Point,
            PartnerID = @PartnerID,
            CategoryID = @CategoryID,
            ProductGroupID = @ProductGroupID,
            Gift = @Gift
            where ID = @ID
            ";

            string sqlProductImages = @"delete from ProductImages where ProductID = @ID;
            INSERT INTO ProductImages
            (ID, Url, ProductID)
            Values
            (@ID, @Url, @ProductID);";

            using (var connection = Connection)
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRows = await connection.ExecuteAsync(sqlProduct,
                            new
                            {
                                ID = product.ID,
                                Name = product.Name,
                                Description = product.Description,
                                Price = product.Price.Amount,
                                Point = product.Coin,
                                PartnerID = product.Partner.ID,
                                CategoryID = product.Category?.ID,
                                ProductGroupID = product.ProductGroupID,
                                Gift = product.Gift,
                                IsActive = product.IsActive,
                            }, transaction);
                        if (product.Images != null && product.Images.Count() > 0)
                        {
                            affectedRows = await connection.ExecuteAsync(sqlProductImages,
                                product.Images.Select(i => new
                                {
                                    ID = product.ID,
                                    Url = i.Url,
                                    ProductID = product.ID,
                                }), transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> SetIsActive(Guid id, bool isActive)
        {

            // string sql = "UPDATE Categories SET IsActive = @IsActive where ID = @ID;";

            // using (var connection = Connection) {
            //     var affectedRows = await connection.ExecuteAsync (sql,
            //         new {
            //             ID = id,
            //                 IsActive = isActive,
            //         });
            // }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<IEnumerable<Product>> GetByCategoryAndPriceRange(Guid categoryID, decimal from, decimal to)
        {
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
                        WHERE       prod.Price >= @from and prod.Price <= @to and prod.CategoryID = @categoryID
                        ORDER BY	Ordering
                        ;";

            List<Product> products = null;
            using (var connection = Connection)
            {
                var productsResult = await connection.QueryAsync(sql, new
                {
                    @from = from,
                    @to = to,
                    @categoryID = categoryID
                });
                if (productsResult != null)
                {

                    var res = from prod in productsResult
                              let partner = new ProductPartner(prod.PartnerID, prod.PartnerName)
                              let price = new Money(prod.Price)
                              let category = prod.CategoryID == null ? null : new ProductCategory(prod.CategoryID, prod.CategoryName)
                              group prod
                              by new Product(prod.ID, prod.Name, prod.Description, partner, price, prod.Point, prod.ProductGroupID, prod.Gift, prod.IsActive) { Category = category } into p
                              select p;

                    products = new List<Product>();
                    foreach (var prod in res)
                    {
                        Product pr = prod.Key;
                        foreach (var img in prod)
                        {
                            if (img != null && img.ImageID != null)
                                pr.AddImage(img.ImageID, img.ImageUrl);
                        }
                        products.Add(pr);
                    }
                }

                //make connections by groupid
                foreach (var prod in products)
                {
                    var connections = products.Where(p => p.ProductGroupID == prod.ProductGroupID && p.ID != prod.ID)
                        .Select(p =>
                        {
                            var cp = new ConnectedProduct(p.ID, p.Name, p.Description, p.Partner, p.Price, p.Coin, p.ProductGroupID, p.Gift) { Category = p.Category };
                            foreach (var i in p.Images)
                            {
                                cp.AddImage(i);
                            }
                            return cp;
                        });
                    foreach (var con in connections)
                    {
                        prod.AddConnectedProduct(con);
                    }
                }
                return products;
            }
        }

        public async Task<IEnumerable<Product>> GetByGroup(Guid groupID)
        {
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
                        WHERE       prod.ProductGroupID = @GroupID
                        ORDER BY	Ordering
                        ;";

            List<Product> products = null;
            using (var connection = Connection)
            {
                var productsResult = await connection.QueryAsync(sql, new
                {
                    @GroupID = groupID
                });
                if (productsResult != null)
                {

                    var res = from prod in productsResult
                              let partner = new ProductPartner(prod.PartnerID, prod.PartnerName)
                              let price = new Money(prod.Price)
                              let category = prod.CategoryID == null ? null : new ProductCategory(prod.CategoryID, prod.CategoryName)
                              group prod
                              by new Product(prod.ID, prod.Name, prod.Description, partner, price, prod.Point, prod.ProductGroupID, prod.Gift, prod.IsActive) { Category = category } into p
                              select p;

                    products = new List<Product>();
                    foreach (var prod in res)
                    {
                        Product pr = prod.Key;
                        foreach (var img in prod)
                        {
                            if (img != null && img.ImageID != null)
                                pr.AddImage(img.ImageID, img.ImageUrl);
                        }
                        products.Add(pr);
                    }
                }

                //make connections by groupid
                foreach (var prod in products)
                {
                    var connections = products.Where(p => p.ProductGroupID == prod.ProductGroupID && p.ID != prod.ID)
                        .Select(p =>
                        {
                            var cp = new ConnectedProduct(p.ID, p.Name, p.Description, p.Partner, p.Price, p.Coin, p.ProductGroupID, p.Gift) { Category = p.Category };
                            foreach (var i in p.Images)
                            {
                                cp.AddImage(i);
                            }
                            return cp;
                        });
                    foreach (var con in connections)
                    {
                        prod.AddConnectedProduct(con);
                    }
                }
                return products;
            }
        }

        public async Task<IEnumerable<Product>> GetRange(int skip, int take, string searchWord)
        {
            string sql = @"SELECT
                                    prod.ID, prod.Name, prod.Description, prod.Price, prod.Point, prod.PartnerID, prod.CategoryID,
                                    prod.ProductGroupID, prod.IsActive, prod.Gift, part.Name as PartnerName, img.ID as ImageID,
                                    cat.Name as CategoryName, img.Url as ImageUrl
                        FROM		Products prod
                        LEFT JOIN	Partners part
                            ON		prod.PartnerID = part.ID
                        LEFT JOIN	Categories cat
                            ON		prod.CategoryID = cat.ID
                        LEFT JOIN	ProductImages img
                            ON		img.ProductID = prod.ID
                        ORDER BY	prod.Ordering
                        OFFSET		@Skip ROWS
                        FETCH NEXT	@Take ROWS ONLY;";

            List<Product> products = null;
            using (var connection = Connection)
            {
                var productsResult = await connection.QueryAsync(sql, new
                {
                    @Skip = skip,
                    @Take = take,
                });
                if (productsResult != null)
                {

                    var res = from prod in productsResult
                              let partner = new ProductPartner(prod.PartnerID, prod.PartnerName)
                              let price = new Money(prod.Price)
                              let category = prod.CategoryID == null ? null : new ProductCategory(prod.CategoryID, prod.CategoryName)
                              group prod
                              by new Product(prod.ID, prod.Name, prod.Description, partner, price, prod.Point, prod.ProductGroupID, prod.Gift, prod.IsActive) { Category = category } into p
                              select p;
                    products = new List<Product>();
                    foreach (var prod in res)
                    {
                        Product pr = prod.Key;
                        foreach (var img in prod)
                        {
                            if (img != null && img.ImageID != null)
                                pr.AddImage(img.ImageID, img.ImageUrl);
                        }
                        products.Add(pr);
                    }
                }
            }
            //make connections by groupid
            foreach (var prod in products)
            {
                var connections = products.Where(p => p.ProductGroupID == prod.ProductGroupID && p.ID != prod.ID)
                    .Select(p =>
                    {
                        var cp = new ConnectedProduct(p.ID, p.Name, p.Description, p.Partner, p.Price, p.Coin, p.ProductGroupID, p.Gift) { Category = p.Category };
                        foreach (var i in p.Images)
                        {
                            cp.AddImage(i);
                        }
                        return cp;
                    });
                foreach (var con in connections)
                {
                    prod.AddConnectedProduct(con);
                }
            }
            return products;
        }

        public async Task<int> Count(string searchWord)
        {
            string sql = @"SELECT Count(ID)
                        FROM		Products;";
            int res = 0;
            using (var connection = Connection)
            {
                res = await connection.QueryFirstAsync<int>(sql);
            }
            return res;
        }
    }
}