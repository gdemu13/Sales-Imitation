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
    public class PartnerRepository : IPartnerRepository {
        private readonly IConfiguration _config;

        public PartnerRepository (IConfiguration config) {
            _config = config;
        }

        private IDbConnection Connection {
            get {
                return new SqlConnection (_config.GetConnectionString ("siconnectionstring"));
            }
        }

        public async Task<IEnumerable<Partner>> GetRange (int skip, int take) {
            string sql = @"SELECT * From Partners
                            ORDER BY Ordering
                            OFFSET     @Skip ROWS
                            FETCH NEXT @Take ROWS ONLY; ";

            IEnumerable<Partner> partners = null;
            using (var connection = Connection) {
                var res = await connection.QueryAsync<PartnerModel> (sql, new {
                    @Skip = skip,
                    @Take = take,
                });
                if (res != null) {
                    partners = res.Select (r => {
                        var partner = new Partner (r.ID, r.Name);

                        partner.Logo = new PartnerLogo (r.LogoUrl);
                        partner.Address = new PartnerAddress (r.Street);
                        partner.ContactInfo = new PartnerContactInfo (r.Number, r.Email);
                        partner.ContactPerson = new PartnerContactPerson (r.ContactPersonFirstName,
                            r.ContactPersonLastName,
                            r.ContactPersonNumber,
                            r.ContactPersonEmail);
                        partner.WebSite = r.WebSite;
                        return partner;
                    });
                }
            }
            return partners;
        }

        private class PartnerModel {
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

        public async Task<Result> Insert (Partner partner) {

            string sql = @"INSERT INTO Partners
            (ID, Name, LogoUrl, Street, Number, Email, ContactPersonFirstName,
            ContactPersonLastName, ContactPersonNumber, ContactPersonEmail, WebSite, IsActive)
            Values
            (@ID, @Name, @LogoUrl, @Street, @Number, @Email, @ContactPersonFirstName,
            @ContactPersonLastName, @ContactPersonNumber, @ContactPersonEmail, @WebSite, @IsActive);";

            using (var connection = Connection) {
                var affectedRows = await connection.ExecuteAsync (sql,
                    new {
                        ID = partner.ID,
                            Name = partner.Name,
                            LogoUrl = partner.Logo.Url,
                            Street = partner.Address?.Street,
                            Number = partner.ContactInfo?.Number,
                            Email = partner.ContactInfo?.Email,
                            ContactPersonFirstName = partner.ContactPerson?.FirstName,
                            ContactPersonLastName = partner.ContactPerson?.LastName,
                            ContactPersonNumber = partner.ContactPerson?.Number,
                            ContactPersonEmail = partner.ContactPerson?.Email,
                            WebSite = partner.WebSite,
                            IsActive = partner.IsActive
                    });
            }

            return await Task.FromResult (new Result ());
        }

        public async Task<Result> Update (Guid id, Partner partner) {

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