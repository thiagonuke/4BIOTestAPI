using _4BIO.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Domain.Interfaces.Client
{
    public interface IBaseRepository<T>
    {
        void Create(List<T> entity);
        Task<List<T>?> GetAll();
    }
}
