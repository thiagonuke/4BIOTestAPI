using _4BIO.Test.API.Validator.Client;
using _4BIO.Test.API.Validator.Shared;
using _4BIO.Test.Application.Client.UseCases.Create;
using _4BIO.Test.Application.Client.UseCases.Delete;
using _4BIO.Test.Application.Client.UseCases.Read;
using _4BIO.Test.Application.Client.UseCases.Update;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace _4BIO.Test.API.Routes.Client
{
    public static class ClientRoutes
    {

        public static void MapClientRoutes(this IEndpointRouteBuilder routes) 
        {
            routes.MapPost("/cliente/criar", async ([FromServices] ClientCreateHandler handler, 
                                                    [FromBody] ClientCreateCommand command) => 
                                             await handler.HandleAsync(command))
                                            .WithName("CriarCliente")
                                            .WithTags("Clientes")
                                            .WithSummary("Cria um novo cliente")
                                            .WithDescription("Endpoint responsável por registrar um novo cliente no sistema."
                                                + " Valida os dados obrigatórios (Nome, Email, CPF, RG e contatos).")
                                            .AddEndpointFilter<ValidationFilter<ClientCreateCommand>>();


            routes.MapGet("/cliente/listar", async ([FromServices] ClientReadHandler handler,
                                                    string? nome, string? email, string? cpf) =>
                                                    await handler.HandleAsync(new ClientReadCommand() {Nome = nome, CPF = cpf, Email = email })).WithName("ListarClientes")
                                                                 .WithTags("Clientes")
                                                                 .WithSummary("Lista clientes cadastrados")
                                                                 .WithDescription("Retorna uma lista de clientes filtrada por nome, email ou CPF. "
                                                                               + "Se nenhum filtro for informado, retorna todos os clientes cadastrados.");

            routes.MapDelete("/cliente/remover/{cpf}", async ([FromServices] ClientDeleteHandler handler,
                                                       [FromRoute] string cpf) =>
                                                       {
                                                           var command = new ClientDeleteCommand { CPF = cpf };
                                                           return await handler.HandleAsync(command);
                                                       }).WithName("RemoverCliente")
                                                            .WithTags("Clientes")
                                                            .WithSummary("Remove um cliente pelo CPF")
                                                            .WithDescription("Remove o cliente cujo CPF for informado na rota. "
                                                                + "Caso o CPF não exista, retorna uma mensagem de erro.");


            routes.MapPut("/cliente/atualizar/{cpf}", async ([FromServices] ClientUpdateHandler handler,
                                                       [FromBody] ClientUpdateCommand command,
                                                       [FromRoute] string cpf) =>
                                                       await handler.HandleAsync(new ClientUpdateCommand() { Cliente = command.Cliente, CPF = cpf}))
                                                       .WithName("AtualizarCliente")
                                                       .WithTags("Clientes")
                                                       .WithSummary("Atualiza dados de um cliente")
                                                       .WithDescription("Atualiza as informações de um cliente existente com base no CPF informado. "
                                                                        + "O corpo da requisição deve conter os novos dados do cliente.").AddEndpointFilter<ValidationFilter<ClientUpdateCommand>>();
        }

    }
}
