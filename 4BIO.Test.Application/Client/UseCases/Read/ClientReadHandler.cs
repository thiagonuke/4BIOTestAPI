using _4BIO.Test.Application.Shared.Abstractions;
using _4BIO.Test.Domain.Entities;
using _4BIO.Test.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Client.UseCases.Read
{
    public class ClientReadHandler : IHandler<ClientReadCommand, ClientReadResponse>
    {
        private readonly IClientRepository _clientRepository;
        public ClientReadHandler(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;

        }

        public Task<ClientReadResponse> HandleAsync(ClientReadCommand command)
        {
            var retorno = new ClientReadResponse();

            List<Cliente>? dados = _clientRepository.GetAll().Result;

            if (dados is null) return Task.FromResult(retorno);

            dados = command.CPF != null ||
                    command.Nome != null ||
                    command.Email != null ?
                    dados.Where(x => (command.CPF == null || x.CPF == command.CPF)
                                && (command.Nome == null || x.Nome == command.Nome)
                                && (command.Email == null || x.Email == command.Email)).ToList() : dados;

            Parallel.ForEach(dados != null ? dados : new List<Domain.Entities.Cliente>(), item =>
            {
                var itemBd = new Dtos.ClientDto()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Email = item.Email,
                    CPF = item.CPF,
                    RG = item.RG,
                    Enderecos = new Dtos.EnderecoDto()
                    {
                        Id = item.Enderecos.Id,
                        Tipo = item.Enderecos.Tipo,
                        CEP = item.Enderecos.CEP,
                        Logradouro = item.Enderecos.Logradouro,
                        Numero = item.Enderecos.Numero,
                        Bairro = item.Enderecos.Bairro,
                        Complemento = item.Enderecos.Complemento,
                        Cidade = item.Enderecos.Cidade,
                        Estado = item.Enderecos.Estado,
                        Referencia = item.Enderecos.Referencia
                    },
                    Contatos = new Dtos.ContatoDto() { 
                        Id = item.Contatos.Id,
                        DDD = item.Contatos.DDD, 
                        Telefone = item.Contatos.Telefone, 
                        Tipo = item.Contatos.Tipo
                    }
                    
                };

                retorno.Clientes.Add(itemBd);
            });

            return Task.FromResult(retorno);
        }
    }
}
