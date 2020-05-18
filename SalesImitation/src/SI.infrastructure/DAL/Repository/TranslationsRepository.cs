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
                    string sqlRemoveLanguages = @"delete from [dbo].[Languages] where Code != 'neutral'";

                    string sqlRemovetranslations = @"delete from [dbo].[Translations]
                                                        where LanguageID != (select ID from [dbo].[Languages] where Code = 'neutral')";

                    string sqlLanguages = @"INSERT INTO [dbo].[Languages]
                                    ([ID] ,[Name] ,[Code],[LastUpdateDate])
                                VALUES
                                    (@ID, @name, @Code, @LastUpdateDate)";

                    string sqlTexts = @"INSERT INTO [dbo].[Translations]
                                    ([ID], [Key] ,[Value] ,[LanguageID],[LastUpdateDate])
                                VALUES
                                    (@ID, @Key, @Value, @LanguageID, @LastUpdateDate)";
                    try
                    {
                        Dictionary<string, Guid> languageMapping = new Dictionary<string, Guid>();
                        foreach (var l in model.Languages)
                            languageMapping.Add(l.Code, Guid.NewGuid());

                        await connection.ExecuteAsync(sqlRemovetranslations, null, trans);
                        await connection.ExecuteAsync(sqlRemoveLanguages, null, trans);

                        var affectedRows = await connection.ExecuteAsync(sqlLanguages,
                       model.Languages.Where(l => l.Code != "neutral").Select(m => new
                       {
                           ID = languageMapping[m.Code],
                           Name = m.Name,
                           Code = m.Code,
                           LastUpdateDate = DateTime.Now
                       }), trans);

                        affectedRows = await connection.ExecuteAsync(sqlTexts,
                          model.Translations.SelectMany(m =>
                             m.Value.Where(v => v.LanguageCode != "neutral").Select(v => new
                             {
                                 ID = Guid.NewGuid(),
                                 Key = m.Key,
                                 Value = v.Value,
                                 LanguageID = languageMapping[v.LanguageCode],
                                 LastUpdateDate = DateTime.Now
                             })
                          ), trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Dictionary<string, string>> GetNeutral()
        {
            var result = new Dictionary<string, string>();

            var sql = @"select *
                            from Translations t
                            where t.LanguageID = (select ID from Languages where Code = 'neutral')
                            ";

            using (var connection = Connection)
            {
                connection.Open();

                var rows = await connection.QueryAsync(sql);
                foreach (var r in rows)
                {
                    result.Add(r.Key, r.Value);
                }
            }

            return result;
        }

        public async Task<Dictionary<string, string>> GetByCountryCode(string code)
        {
            var result = new Dictionary<string, string>();

            var sql = @"select *
                            from Translations t
                            where t.LanguageID = (select ID from Languages where Code = @Code)
                            ";

            using (var connection = Connection)
            {
                connection.Open();

                var rows = await connection.QueryAsync(sql, new {Code = code});
                foreach (var r in rows)
                {
                    result.Add(r.Key, r.Value);
                }
            }

            return result;
        }

        public async Task<TranslationModel> GetAllLanguages()
        {
            TranslationModel result = new TranslationModel(await GetNeutral());

            var sql = @"select *
                        from Languages l
                        left join Translations t on t.LanguageID = l.ID";

            using (var connection = Connection)
            {
                connection.Open();

                var rows = await connection.QueryAsync(sql);

                var res = from r in rows
                          group r.Value by new { Key = r.Key, Code = r.Code } into g
                          select g;


                foreach (var r in res)
                {
                    foreach (var t in r)
                    {
                        result.AddText(r.Key.Key, new TextModel
                        {
                            LanguageCode = r.Key.Code,
                            Value = t
                        });
                    }
                }

                var distRows = rows
                    .GroupBy(p => p.Code)
                    .Select(g => g.First())
                    .ToList();

                result.Languages.AddRange(distRows.Select(r => new LanguageModel
                {
                    Code = r.Code,
                    Name = r.Name
                }));
            }

            return result;
        }

    }
}