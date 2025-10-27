using _4BIO.Test.Application.Dtos;
using _4BIO.Test.Application.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Update
{
    public class ClientUpdateCommand : ICommand
    {
        [JsonIgnore]
        public string CPF { get; set; } = string.Empty;
        public ClientDto Cliente { get; set; }

        public ClientUpdateCommand() 
        { 
            Cliente = new ClientDto();
        }    

    }
}
