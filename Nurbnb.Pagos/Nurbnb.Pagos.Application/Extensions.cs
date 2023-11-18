using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Nurbnb.Pagos.Domain.Factories;
using System.Reflection;

namespace Nurbnb.Pagos.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
           services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<IPagoFactory, PagoFactory>();
            services.AddSingleton<ICatalogoFactory, CatalogoFactory>();
            services.AddSingleton<ICatalogoDevolucionFactory, CatalogoDevolucionFactory>();
            services.AddSingleton<IDevolucionFactory, DevolucionFactory>();

            return services;
        }

    }
}
