using _4BIO.Test.Application.Client.UseCases.Update;
using FluentValidation;

namespace _4BIO.Test.API.Validator.Client
{
    public class ClientUpdateValidator : AbstractValidator<ClientUpdateCommand>
    {
        public ClientUpdateValidator() 
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
}
