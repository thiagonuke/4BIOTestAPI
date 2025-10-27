using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Domain.Entities
{
    public class Contatos
    {
        public int Id { get; set; } 
        public string Tipo { get; set; } = string.Empty;
        public int DDD { get; set; }
        public decimal Telefone { get; set;} 

    }
}
