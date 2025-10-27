using _4BIO.Test.Application.Shared.Abstractions;
using _4BIO.Test.Domain.Entities;
using _4BIO.Test.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Create
{
    public class ClientCreateHandler : IHandler<ClientCreateCommand, ClientCreateResponse>
    {
        private readonly IClientRepository _clientRepository;


        public ClientCreateHandler(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;
        }

        public Task<ClientCreateResponse> HandleAsync(ClientCreateCommand command)
        {
            List<Cliente>? ListCliente = _clientRepository.GetAll().Result;

            ListCliente = ListCliente ?? new List<Cliente>();

            ListCliente.Add(new Cliente()
            {
                Id = ListCliente.Any() ? ListCliente.Max(c => c.Id) + 1 : 1,
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


            return Task.FromResult(new ClientCreateResponse()
            {
                Cliente = command.Cliente,
            });

        }
    }
}
