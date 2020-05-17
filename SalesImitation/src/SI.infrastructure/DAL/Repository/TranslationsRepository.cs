using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SI.Application.Translations;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Infrastructure.DAL.Repository
{
    public class TranslationsRepository : ITranslationsRepository
    {
        private readonly IConfiguration _config;

        public TranslationsRepository(IConfiguration config)
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

        public async Task<Result> Save(TranslationModel model)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    string sqlLanguages = @"INSERT INTO [dbo].[Languages]
                                    ([ID] ,[Name] ,[Code],[LastUpdateDate])
                                VALUES
                                    (@ID, @name, @Code, @LastUpdateDate)";

                    string sqlTexts = @"INSERT INTO [dbo].[Languages]
                                    ([Key], [Key] ,[Value] ,[LanguageID],[LastUpdateDate])
                                VALUES
                                    (@ID, @Key, @Value, @LanguageID, @LastUpdateDate)";
                    try
                    {

                        var affectedRows = await connection.ExecuteAsync(sqlLanguages,
                        model.Select(m => new
                        {
                            ID = m.Value.ID,
                            Name = m.Value.LanguageName,
                            Code = m.Key,
                            LastUpdateDate = DateTime.Now
                        }), trans);

                        affectedRows = await connection.ExecuteAsync(sqlTexts,
                           model.SelectMany(m => m.Value.Select(v => new
                           {
                               ID = Guid.NewGuid(),
                               Key = v.Key,
                               Value = v.Value,
                               LanguageID = m.Value.ID,
                               LastUpdateDate = DateTime.Now,
                           })), trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public Task<TranslationModel> GetAllLanguages()
        {
            throw new NotImplementedException();
        }

    }
}