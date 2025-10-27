using _4BIO.Test.Application.Dtos;
using _4BIO.Test.Application.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Create
{
    public class ClientCreateResponse : IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public ClientDto Cliente { get; set; }

        public ClientCreateResponse()
        {
            Cliente = new ClientDto();
        }
    }
}
