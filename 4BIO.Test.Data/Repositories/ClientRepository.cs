using _4BIO.Test.Data.Context;
using _4BIO.Test.Domain.Entities;
using _4BIO.Test.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Data.Repositories
{
    public class ClientRepository : BaseRepository<Cliente>, IClientRepository
    {
        private readonly JsonDatabase _database;

        public ClientRepository(JsonDatabase database) : base(database) {

            _database = database;

        }

    }

}
