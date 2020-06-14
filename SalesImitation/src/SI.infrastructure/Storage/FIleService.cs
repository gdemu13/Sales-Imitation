using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SI.Common.Models;

namespace SI.Infrastructure.Storage
{
    public class FileService : IFIleService
    {

        private readonly IConfiguration _config;

        public FileService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Result<string>> SaveFile(IFormFile file)
        {
            int maxFile;
            if (!int.TryParse(_config["media:images:maxSize"], out maxFile))
                maxFile = 5 * 1024 * 1024;
            if (file.Length > maxFile)
                return new Result<string>(false, "ფაილის ზომა ლიმიტზე მეტია", string.Empty);

            // var directoryPath = "D:\\si\\images\\";
            var directoryPath = _config["media:images:path"];
            var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();

            Directory.CreateDirectory(directoryPath);

            if (file.Length <= 0)
                return new Result<string>(false, "ფაილი ცარიელია", string.Empty);

            var filePath = Path.Combine(directoryPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Result<string>.CreateSuccessReqest(fileName);
        }

        public async Task<Result<string>> SavePersonalFile(IFormFile file, Guid userID)
        {
            int maxFile;
            if (!int.TryParse(_config["media:images:maxSize"], out maxFile))
                maxFile = 5 * 1024 * 1024;
            if (file.Length > maxFile)
                return new Result<string>(false, "ფაილის ზომა ლიმიტზე მეტია", string.Empty);

            // var directoryPath = "D:\\si\\images\\";
            var directoryPath = _config["media:images:personalpath"];
            var fileName = userID.ToString() + Guid.NewGuid() + "." + file.FileName.Split('.').Last();

            Directory.CreateDirectory(directoryPath);

            if (file.Length <= 0)
                return new Result<string>(false, "ფაილი ცარიელია", string.Empty);

            var filePath = Path.Combine(directoryPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Result<string>.CreateSuccessReqest(fileName);
        }

        public async Task<byte[]> GetFile(string fileName)
        {
            var directoryPath = _config["media:images:path"];
            return await File.ReadAllBytesAsync(directoryPath + fileName);
        }

        public async Task<byte[]> GetPersonalFile(string fileName)
        {
            var directoryPath = _config["media:images:personalpath"];
            return await File.ReadAllBytesAsync(directoryPath + fileName);
        }

        public (string fileType, byte[] archiveData, string archiveName) FetechFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(Path.Combine("D:\\webroot\\", subDirectory)).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        var theFile = archive.CreateEntry(file);
                        using (var streamWriter = new StreamWriter(theFile.Open()))
                        {
                            streamWriter.Write(File.ReadAllText(file));
                        }

                    });
                }

                return ("application/zip", memoryStream.ToArray(), zipName);
            }
        }

        public static string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
    }
}