using _4BIO.Test.Application.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Delete
{
    public class ClientDeleteCommand : ICommand
    {
        public string CPF { get; set; } = string.Empty;
    }
}
