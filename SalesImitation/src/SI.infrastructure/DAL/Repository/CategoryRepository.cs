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
    public class CategoryRepository : ICategoryRepository {
        private readonly IConfiguration _config;

        public CategoryRepository (IConfiguration config) {
            _config = config;
        }

        private IDbConnection Connection {
            get {
                return new SqlConnection (_config.GetConnectionString ("siconnectionstring"));
            }
        }

        public async Task<Category> Get (Guid id) {
            string sql = "SELECT * From Categories Where ID = @ID;";
            Category category = null;
            using (var connection = Connection) {
                var res = await connection.QueryFirstOrDefaultAsync<CategoryModel> (sql, new { ID = id });
                if (res != null) {
                    category = new Category (res.ID, res.Name);
                    category.IsActive = res.IsActive;
                }
            }
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll () {
            string sql = "SELECT * From Categories;";
            IEnumerable<Category> categories = null;
            using (var connection = Connection) {
                var res = await connection.QueryAsync<CategoryModel> (sql);
                if (res != null) {
                    categories = res.Select (r => {
                        var c = new Category (r.ID, r.Name);
                        c.IsActive = r.IsActive;
                        return c;
                    });
                }
            }
            return categories;
        }

        private class CategoryModel {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }

        public async Task<Result> Insert (Category category) {

            string sql = "INSERT INTO Categories (ID, Name, IsActive) Values (@ID, @Name, @IsActive);";

            using (var connection = Connection) {
                System.Console.WriteLine ("repo " + sql);
                var affectedRows = await connection.ExecuteAsync (sql,
                    new {
                        ID = category.ID,
                            Name = category.Name,
                            IsActive = category.IsActive
                    });
            }

            return await Task.FromResult (Result.CreateSuccessReqest());
        }

        public async Task<Result> UpdateName (Guid id, string name) {

            string sql = "UPDATE Categories SET Name = @Name where ID = @ID;";

            using (var connection = Connection) {
                var affectedRows = await connection.ExecuteAsync (sql,
                    new {
                        ID = id,
                            Name = name,
                    });
            }

            return await Task.FromResult (Result.CreateSuccessReqest());
        }

        public async Task<Result> SetIsActive (Guid id, bool isActive) {

            string sql = "UPDATE Categories SET IsActive = @IsActive where ID = @ID;";

            using (var connection = Connection) {
                var affectedRows = await connection.ExecuteAsync (sql,
                    new {
                        ID = id,
                            IsActive = isActive,
                    });
            }

            return await Task.FromResult (Result.CreateSuccessReqest());
        }
    }
}