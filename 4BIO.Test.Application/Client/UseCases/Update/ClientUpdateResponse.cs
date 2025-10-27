using _4BIO.Test.Application.Dtos;
using _4BIO.Test.Application.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Update
{
    public class ClientUpdateResponse : IResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public ClientDto Client { get; set; }

        public ClientUpdateResponse() 
        {
            Client = new ClientDto();
        }
    }
}
