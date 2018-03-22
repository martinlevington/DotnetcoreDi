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

            Func<IServiceProvider, object> factoryFunc = provider =>
            {
                var factory = provider.GetRequiredService<TFactory>();
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
