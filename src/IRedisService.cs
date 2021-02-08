using StackExchange.Redis;

namespace Faactory.Extensions.Redis
{
    public interface IRedisService
    {
        IConnectionMultiplexer Connection { get; }
    }
}
