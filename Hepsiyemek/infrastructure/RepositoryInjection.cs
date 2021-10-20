using Hepsiyemek.Helpers;
using Hepsiyemek.infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiyemek.infrastructure
{
    public class RepositoryInjection
    {
        public static void Add(IServiceCollection services)
        {

            services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
