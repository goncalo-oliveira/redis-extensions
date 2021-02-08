using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Faactory.Extensions.Redis
{
    internal class RedisService : IRedisService
    {
        private Lazy<IConnectionMultiplexer> connection;

        public RedisService( IOptions<RedisServiceOptions> optionsAccessor )
        {
            var options = optionsAccessor.Value;

            connection = new Lazy<IConnectionMultiplexer>( () =>
            {
                var config = ConfigurationOptions.Parse( options.Connection );

                return Task.Run( async () => await ConnectionMultiplexer.ConnectAsync( config ) )
                    .GetAwaiter()
                    .GetResult();
            } );
        }

        public IConnectionMultiplexer Connection => connection.Value;
    }
}
