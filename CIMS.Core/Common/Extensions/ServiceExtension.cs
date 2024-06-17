using CIMS.Core.Common.Attributes;
using System.Reflection;

namespace CIMS.Core.Common.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServiceFromAssembly(this IServiceCollection services, string assemblyName)
        {
            var assembly = Assembly.Load(assemblyName);
            var types = assembly.GetTypes()
                .Where(t => t.IsClass && t.IsAbstract == false && t.GetCustomAttribute<RegisterServiceAttribute>() != null)
                .ToList();

            foreach (var type in types)
            {
                var serviceAttribute = type.GetCustomAttribute<RegisterServiceAttribute>();

                if (serviceAttribute == null)
                {
                    throw new InvalidOperationException("[RegisterServiceAttribute] was not configured");
                }

                var interfaces = type
                    .GetInterfaces()
                    .Where(x => (x.Namespace ?? string.Empty).StartsWith(assemblyName));
                if (interfaces.Count() > 0)
                {
                    var serviceType = interfaces.First();

                    switch (serviceAttribute.ServiceLifetime)
                    {
                        case ServiceLifetime.Transient:
                            services.AddTransient(serviceType, type);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(serviceType, type);
                            break;
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(serviceType, type);
                            break;
                        default:
                            throw new InvalidOperationException($"Unsupported service life time: {serviceAttribute.ServiceLifetime}");
                    }
                }
                else
                {
                    switch (serviceAttribute.ServiceLifetime)
                    {
                        case ServiceLifetime.Transient:
                            services.AddTransient(type);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(type);
                            break;
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(type);
                            break;
                        default:
                            throw new InvalidOperationException($"Unsupported service life time: {serviceAttribute.ServiceLifetime}");
                    }
                }
            }

            return services;
        }
    }
}
