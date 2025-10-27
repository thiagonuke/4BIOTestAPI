using _4BIO.Test.Application.Shared.Abstractions;
using _4BIO.Test.Domain.Entities;
using _4BIO.Test.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Delete
{
    public class ClientDeleteHandler : IHandler<ClientDeleteCommand, ClientDeleteResponse>
    {
        private readonly IClientRepository _clientRepository;

        public ClientDeleteHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<ClientDeleteResponse> HandleAsync(ClientDeleteCommand command)
        {
            if (command.CPF == null || command.CPF.Length > 11 || command.CPF.Length < 11 || !Regex.IsMatch(command.CPF, @"^\d+$")) return Task.FromResult(new ClientDeleteResponse() {Message = "O CPF é obrigatório e deve conter 11 dígitos!", Success = false});

            List<Cliente>? ListCliente = _clientRepository.GetAll().Result;

            if (ListCliente == null ||
                ListCliente.Count == 0 ||
                !ListCliente.Any(t => t.CPF == command.CPF)) return Task.FromResult(new ClientDeleteResponse() { Message = "Nenhum CPF cadastrado foi encontrado para exclusão!", Success = false });

            ListCliente.RemoveAll(t => t.CPF == command.CPF);

             _clientRepository.Create(ListCliente);

            return Task.FromResult(new ClientDeleteResponse()
            {
                Message = "Excluído com sucesso!",
                Success = true
            });
        }
    }
}
