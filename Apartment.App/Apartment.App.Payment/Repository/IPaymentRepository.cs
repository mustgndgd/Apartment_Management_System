using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB_CRUD.Models;

namespace MongoDB_CRUD.Repository
{
    public interface IPaymentRepository
    {
        Task<List<PaymentRecord>> GetAllAsync();
        Task<PaymentRecord> GetByIdAsync(string id);
        Task<PaymentRecord> CreateAsync(PaymentRecord customer);
        Task UpdateAsync(string id, PaymentRecord customer);
        Task DeleteAsync(string id);
    }
}
