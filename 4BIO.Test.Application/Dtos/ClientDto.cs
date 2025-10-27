using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Dtos
{
    public class ClientDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;

        public ContatoDto Contatos { get; set; }
        public EnderecoDto Enderecos { get; set; }

        public ClientDto()
        {
            Contatos = new ContatoDto();
            Enderecos = new EnderecoDto();

        }
    }
}
