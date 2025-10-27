using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Domain.Entities
{
    public class Contatos
    {
        [SwaggerSchema(ReadOnly = true, Description = "ID gerado automaticamente pelo banco")]
        public int Id { get; set; } 
        public string Tipo { get; set; } = string.Empty;
        public int DDD { get; set; }
        public decimal Telefone { get; set;} 

    }
}
