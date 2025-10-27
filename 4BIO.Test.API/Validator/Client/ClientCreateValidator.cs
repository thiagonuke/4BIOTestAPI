using _4BIO.Test.Application.Client.UseCases.Create;
using _4BIO.Test.Application.Dtos;
using FluentValidation;

namespace _4BIO.Test.API.Validator.Client
{
    public class ClientCreateValidator : AbstractValidator<ClientCreateCommand>
    {

        public ClientCreateValidator()
        {

            RuleFor(t => t.Cliente.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatorio!")
                .MaximumLength(100);

            RuleFor(t => t.Cliente.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(t => t.Cliente.CPF)
                .NotEmpty()
                .WithMessage("O CPF é obrigatorio!")
                .MinimumLength(11)
                .MaximumLength(11);

            RuleFor(t => t.Cliente.RG)
                .NotEmpty()
                .WithMessage("O RG é obrigatorio!")
                .MinimumLength(9);

            RuleFor(x => x.Cliente.Contatos)
                .SetValidator(new ContatosValidator());

            RuleFor(x => x.Cliente.Enderecos)
                .SetValidator(new EnderecosValidator());
        }

    }


    public class ContatosValidator : AbstractValidator<ContatoDto>
    {  
        public ContatosValidator()
        {

            RuleFor(t => t.Tipo)
                 .NotEmpty()
                 .WithMessage("O Tipo é obrigatorio!")
                 .Must(t => new[] { "Residencial", "Comercial", "Celular" }.Contains(t))
                 .WithMessage("A Tipo informado não é valido! Apenas os valores Residencial, Comercial ou Celular");

            RuleFor(t => t.DDD)
                 .NotEmpty()
                 .WithMessage("O DDD é obrigatorio!");

            RuleFor(t => t.Telefone)
                 .NotEmpty()
                 .GreaterThanOrEqualTo(8)
                 .WithMessage("O Telefone deve conter 8 dígitos!");

        }
    
    
    }


    public class EnderecosValidator : AbstractValidator<EnderecoDto>
    {  
        public EnderecosValidator()
        {
            RuleFor(t => t.CEP)
                 .NotEmpty()
                 .WithMessage("O CEP é obrigatorio!")
                 .MinimumLength(8)
                 .MaximumLength(8);

            RuleFor(t => t.Tipo)
                 .NotEmpty()
                 .WithMessage("O Tipo é obrigatorio!")
                 .Must(t => new[] { "Preferencial", "Entrega", "Cobrança" }.Contains(t))
                 .WithMessage("A Tipo informado não é valido! Apenas os valores Preferencial, Entrega ou Cobrança");
                 

            RuleFor(t => t.Cidade)
                 .NotEmpty()
                 .WithMessage("O Cidade é obrigatorio!");

            RuleFor(t => t.Estado)
                 .NotEmpty()
                 .WithMessage("O Estado é obrigatorio!");
        }
        
    
    }

}
