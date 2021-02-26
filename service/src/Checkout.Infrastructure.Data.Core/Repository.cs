namespace Checkout.Infrastructure.Data.Core
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading.Tasks;
    using Domain.Core;
    using Microsoft.Extensions.Caching.Distributed;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : AggregateRoot
    {
        private readonly IDistributedCache _cache;

        public Repository(IDistributedCache cache)
        {
            _cache = cache ??
                          throw new ArgumentNullException(nameof(cache));
        }

        public async Task AddAsync(TEntity item)
        {
            if (item != null)
                await SaveChangesAsync(item);
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            if (id != default)
            {
                var result = await _cache.GetAsync(id.ToString());

                if (result != null)
                    return await ConvertToObjectAsync(result) as TEntity;
            }

            return null;
        }

        public async Task ModifyAsync(TEntity item)
        {
            //if (item != null)
            //    await GetSet()
            //        .UpdateAsync(item);
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(TEntity item)
        {
            if (item != null)
                await _cache
                    .RemoveAsync(item.Id.ToString());
        }

        private async Task<byte[]> ConvertToByteArrayAsync(object obj)
        {
            var binaryFormatter = new BinaryFormatter();

            await using var stream = new MemoryStream();
            binaryFormatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        private async Task<object> ConvertToObjectAsync(byte[] bytes)
        {
            await using var stream = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();
            await stream.WriteAsync(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return binaryFormatter.Deserialize(stream);
        }

        private async Task SaveChangesAsync(TEntity item)
        {
            var serialized = await ConvertToByteArrayAsync(item);
            var cacheDuration = int.Parse(Environment.GetEnvironmentVariable("ConnectionStrings__FinanceConnectionString"));
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(cacheDuration));
            await _cache
                .SetAsync(item.Id.ToString(), serialized, options);
        }
    }
}