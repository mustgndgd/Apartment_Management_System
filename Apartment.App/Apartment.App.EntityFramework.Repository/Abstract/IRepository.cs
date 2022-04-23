 
using System.Linq;
using System.Text;
using Apartment.App.Domain.Entities;

namespace Apartment.App.DataAccessEntityFramework.Repository.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
