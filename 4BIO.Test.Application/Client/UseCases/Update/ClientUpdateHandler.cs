using _4BIO.Test.Application.Client.UseCases.Delete;
using _4BIO.Test.Application.Shared.Abstractions;
using _4BIO.Test.Domain.Entities;
using _4BIO.Test.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Update
{
    public class ClientUpdateHandler : IHandler<ClientUpdateCommand, ClientUpdateResponse>
    {
        private readonly IClientRepository _clientRepository;

        public ClientUpdateHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<ClientUpdateResponse> HandleAsync(ClientUpdateCommand command)
        {
            List<Cliente>? ListCliente = _clientRepository.GetAll().Result;

            if (ListCliente == null ||
                ListCliente.Count == 0 ||
               !ListCliente.Any(t => t.CPF == command.Cliente.CPF)) return Task.FromResult(new ClientUpdateResponse() { Message = "Nenhum CPF cadastrado foi encontrado para Atualização!", Success = false });

            if (command.CPF == null || command.CPF.Length > 11 || command.CPF.Length < 11 || !Regex.IsMatch(command.CPF, @"^\d+$")) return Task.FromResult(new ClientUpdateResponse() { Message = "O CPF é obrigatório e deve conter 11 dígitos!", Success = false });

            int IdDb = ListCliente.Where(t => t.CPF == command.CPF).First().Id;

            ListCliente.RemoveAll(t => t.CPF == command.CPF);

            ListCliente.Add(new Cliente()
            {
                Id = IdDb,
                Nome = command.Cliente.Nome,
                Email = command.Cliente.Email,
                CPF = command.Cliente.CPF,
                RG = command.Cliente.RG,
                Contatos = new Domain.Entities.Contatos()
                {
                    Tipo = command.Cliente.Contatos.Tipo,
                    DDD = command.Cliente.Contatos.DDD,
                    Telefone = command.Cliente.Contatos.Telefone
                },
                Enderecos = new Domain.Entities.Enderecos()
                {
                    Tipo = command.Cliente.Enderecos.Tipo,
                    CEP = command.Cliente.Enderecos.CEP,
                    Logradouro = command.Cliente.Enderecos.Logradouro,
                    Numero = command.Cliente.Enderecos.Numero,
                    Bairro = command.Cliente.Enderecos.Bairro,
                    Complemento = command.Cliente.Enderecos.Complemento,
                    Cidade = command.Cliente.Enderecos.Cidade,
                    Estado = command.Cliente.Enderecos.Estado,
                    Referencia = command.Cliente.Enderecos.Referencia
                }
            });

            _clientRepository.Create(ListCliente);

            return Task.FromResult(new ClientUpdateResponse()
            {
                Message = "Atualizado com sucesso!",
                Success = true,
                Client = command.Cliente
            });
        }
    }
}
