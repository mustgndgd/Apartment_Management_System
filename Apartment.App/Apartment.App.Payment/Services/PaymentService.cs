using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;

namespace MongoDB_CRUD.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _customerRepository;

        public PaymentService(IPaymentRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<List<PaymentRecord>> GetAllAsync()
        {
            return _customerRepository.GetAllAsync();
        }

        public Task<PaymentRecord> GetByIdAsync(string id)
        {
            return _customerRepository.GetByIdAsync(id);
        }

        public Task<PaymentRecord> CreateAsync(PaymentRecord record)
        {
            return _customerRepository.CreateAsync(record);
        }

        public Task UpdateAsync(string id, PaymentRecord record)
        {
            return _customerRepository.UpdateAsync(id, record);
        }

        public Task DeleteAsync(string id)
        {
            return _customerRepository.DeleteAsync(id);
        }
    }
}
