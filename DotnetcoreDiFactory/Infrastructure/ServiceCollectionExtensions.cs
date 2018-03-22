using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetcoreDiFactory.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFactory<T, TFactory>(this IServiceCollection collection, ServiceLifetime lifetime = ServiceLifetime.Transient)
            where T : class where TFactory : class, IServiceFactory<T>
        {
            collection.AddScoped<TFactory>();

            TFactory FactoryProvider(IServiceProvider p) => p.GetRequiredService<TFactory>();

            Func<IServiceProvider, object> factoryFunc = provider =>
            {
                var factory = FactoryProvider(provider);
                return factory.Build();
            };

            // add new 
            var descriptor = new ServiceDescriptor(
                typeof(T), factoryFunc, lifetime);
            collection.Add(descriptor);
            return collection;
        }

     
    }
}
