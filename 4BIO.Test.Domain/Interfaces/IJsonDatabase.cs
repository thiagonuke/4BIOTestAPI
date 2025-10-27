using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Domain.Interfaces
{
    public interface IJsonDatabase
    {
        void SaveChanges<T>(T entity);
        List<T>? GetAll<T>();
    }
}
