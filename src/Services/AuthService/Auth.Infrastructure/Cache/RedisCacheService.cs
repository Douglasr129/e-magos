using StackExchange.Redis;
namespace Auth.Infrastructure.Cache
{
    /// <summary>
    /// Serviço de cache usando Redis.
    /// </summary>
    public class RedisCacheService
    {
        private readonly IDatabase _db;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task SetAsync(string key, string value, TimeSpan? expiry = null)
        {
            _ = await _db.StringSetAsync(key, value, expiry.HasValue ? (Expiration)expiry.Value : Expiration.Default);
        }

        public async Task<string?> GetAsync(string key)
        {
            return await _db.StringGetAsync(key);
        }
    }

}
