using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Domain.Entities
{
    public class Enderecos
    {
        [SwaggerSchema(ReadOnly = true, Description = "ID gerado automaticamente pelo banco")]
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;

    }
}
