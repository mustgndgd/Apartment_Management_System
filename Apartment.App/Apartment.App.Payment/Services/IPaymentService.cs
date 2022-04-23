using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB_CRUD.Models;

namespace MongoDB_CRUD.Services
{
    public interface IPaymentService
    {
        Task<List<PaymentRecord>> GetAllAsync();
        Task<PaymentRecord> GetByIdAsync(string id);
        Task<PaymentRecord> CreateAsync(PaymentRecord record);
        Task UpdateAsync(string id, PaymentRecord record);
        Task DeleteAsync(string id);
    }
}
