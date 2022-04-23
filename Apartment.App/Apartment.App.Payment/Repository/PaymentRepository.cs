using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUD.Models;

namespace MongoDB_CRUD.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IMongoCollection<PaymentRecord> _collection;
        private readonly DbConfiguration _settings;
        public PaymentRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<PaymentRecord>(_settings.CollectionName);
        }

        public Task<List<PaymentRecord>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<PaymentRecord> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<PaymentRecord> CreateAsync(PaymentRecord record)
        {
            await _collection.InsertOneAsync(record).ConfigureAwait(false);
            return record;
        }
        public Task UpdateAsync(string id, PaymentRecord record)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, record);
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
