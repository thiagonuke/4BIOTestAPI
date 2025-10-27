using _4BIO.Test.Data.Context;
using _4BIO.Test.Data.Repositories;
using _4BIO.Test.Domain.Interfaces.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4BIO.Test.Data
{
    public static class ServicesExtensions
    {

        public static void ConfigureAplicationData(this IServiceCollection services)
        {
            //services.AddScoped<IBaseRepository>, BaseRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddTransient<JsonDatabase>();

        }

    }
}
