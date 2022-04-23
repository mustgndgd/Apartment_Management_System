using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.DataAccess.EntityFramework;
using Apartment.App.DataAccessEntityFramework.Repository.Abstract;

namespace Apartment.App.DataAccessEntityFramework.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext Context { get; }
        public UnitOfWork(AppDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
