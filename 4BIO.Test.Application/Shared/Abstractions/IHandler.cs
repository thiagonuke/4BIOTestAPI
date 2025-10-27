using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application.Shared.Abstractions
{
    public interface IHandler<TCommand, TResponse> 
        where TCommand : ICommand
        where TResponse : IResponse
    {
        Task<TResponse> HandleAsync(TCommand command);
    }
}
