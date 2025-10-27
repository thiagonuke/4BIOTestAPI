using _4BIO.Test.Domain.Entities;
using _4BIO.Test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace _4BIO.Test.Data.Context
{
    public class JsonDatabase : IJsonDatabase
    {
        private readonly string _filePath = string.Empty;

        public JsonDatabase()
        {
            _filePath = Path.Combine(
                   Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                   "ClientDb.json"
               );

            var dir = Path.GetDirectoryName(_filePath)!;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

        }

        public void SaveChanges<T>(T entity) => File.WriteAllText(_filePath, JsonSerializer.Serialize(entity, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            }));


        public List<T>? GetAll<T>()
        {
            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, 
                IgnoreReadOnlyProperties = true,     
            });
        }

    }
}

