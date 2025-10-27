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
        public ClientDto Cliente { get; set; }

        public ClientCreateResponse()
        {
            Cliente = new ClientDto();
        }
    }
}
