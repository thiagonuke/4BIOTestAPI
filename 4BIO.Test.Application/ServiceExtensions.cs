using _4BIO.Test.Application.Client.UseCases.Create;
using _4BIO.Test.Application.Client.UseCases.Delete;
using _4BIO.Test.Application.Client.UseCases.Read;
using _4BIO.Test.Application.Client.UseCases.Update;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureAplicationService(this IServiceCollection services)
        {
            services.AddTransient<ClientCreateHandler>();
            services.AddTransient<ClientReadHandler>();
            services.AddTransient<ClientDeleteHandler>();
            services.AddTransient<ClientUpdateHandler>();
        
        }
        
    }
}
