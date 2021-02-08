using System;
using Faactory.Extensions.Redis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RedisServiceExtensions
    {
        public static IServiceCollection AddRedisService( this IServiceCollection services )
        {
            return services.AddSingleton<IRedisService, RedisService>();
        }

        public static IServiceCollection AddRedisService( this IServiceCollection services, Action<RedisServiceOptions> configure )
        {
            AddRedisService( services );
            ConfigureRedisService( services, configure );

            return services;
        }

        public static IServiceCollection ConfigureRedisService( this IServiceCollection services, Action<RedisServiceOptions> configure )
        {
            return services.Configure<RedisServiceOptions>( configure );
        }
    }
}
