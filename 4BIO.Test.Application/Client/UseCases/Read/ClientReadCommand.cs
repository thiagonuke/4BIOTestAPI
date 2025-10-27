using _4BIO.Test.Application.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Read
{
    public class ClientReadCommand : ICommand
    {
        public string? Nome { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? CPF { get; set; } = string.Empty;
    }
}
