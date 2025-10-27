using _4BIO.Test.Application.Dtos;
using _4BIO.Test.Application.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Create
{
    public class ClientCreateCommand : ICommand 
    {
        public ClientDto Cliente { get; set; }

        public ClientCreateCommand() 
        { 
            Cliente = new ClientDto();
        }
        
    }



}
