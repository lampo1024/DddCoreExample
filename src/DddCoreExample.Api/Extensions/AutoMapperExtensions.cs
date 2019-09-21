using AutoMapper;
using DddCoreExample.Api.Extensions.AutoMapperConfig;
using Microsoft.Extensions.DependencyInjection;

namespace DddCoreExample.Api.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DddCoreMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
