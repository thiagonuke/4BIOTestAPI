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

            if (ListCliente.Any(t => t.CPF == command.Cliente.CPF)) return Task.FromResult(new ClientCreateResponse() { Message = "O CPF já está cadastrado!", Success = false });
           
            int IdBd = ListCliente.Any() ? ListCliente.Max(c => c.Id) + 1 : 1;
           
            ListCliente.Add(new Cliente()
            {
                Id = IdBd,
                Nome = command.Cliente.Nome,
                Email = command.Cliente.Email,
                CPF = command.Cliente.CPF,
                RG = command.Cliente.RG,
                Contatos = new Domain.Entities.Contatos()
                {
                    Id = IdBd,
                    Tipo = command.Cliente.Contatos.Tipo,
                    DDD = command.Cliente.Contatos.DDD,
                    Telefone = command.Cliente.Contatos.Telefone
                },
                Enderecos = new Domain.Entities.Enderecos()
                {
                    Id = IdBd,
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

            command.Cliente.Id = IdBd;
            command.Cliente.Enderecos.Id = IdBd;
            command.Cliente.Contatos.Id = IdBd;

            return Task.FromResult(new ClientCreateResponse()
            {
                Message = "Salvo com sucesso!",
                Success = true,
                Cliente = command.Cliente,
            });

        }
    }
}
