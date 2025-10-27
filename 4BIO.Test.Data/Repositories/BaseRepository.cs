using _4BIO.Test.Data.Context;
using _4BIO.Test.Domain.Interfaces;
using _4BIO.Test.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly IJsonDatabase _database;

        public BaseRepository(IJsonDatabase database) 
        { 
            _database = database;
        }

        public void Create(List<T> entity) => _database.SaveChanges(entity);
        public Task<List<T>?> GetAll() => Task.FromResult(_database.GetAll<T>());

    }
}
