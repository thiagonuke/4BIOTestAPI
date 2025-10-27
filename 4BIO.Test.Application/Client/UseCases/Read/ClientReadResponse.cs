using _4BIO.Test.Application.Dtos;
using _4BIO.Test.Application.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Read
{
    public class ClientReadResponse : IResponse
    {
        public List<ClientDto> Clientes { get; set; } 

        public ClientReadResponse() {

            Clientes = new List<ClientDto>();
        }
    }

   
}
