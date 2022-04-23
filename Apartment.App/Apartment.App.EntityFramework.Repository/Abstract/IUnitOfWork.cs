using System;
using Apartment.App.DataAccess.EntityFramework;

namespace Apartment.App.DataAccessEntityFramework.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext Context { get; }
        void Commit();

    }
}
