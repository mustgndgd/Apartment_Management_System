using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apartment.App.Business.Abstract;
using Apartment.App.DataAccessEntityFramework.Repository.Abstract;
using Apartment.App.Domain.Entities;
using Apartment.App.Domain.Entities.IdentityEntities;

namespace Apartment.App.Business.Concrete
{
    public class InvoiceService:IinvoiceService
    {
        private readonly IRepository<Invoice> repository;
        private readonly IUnitOfWork unitOfWork;
        public InvoiceService(IRepository<Invoice> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public List<Invoice> GetAllInvocies()
        {
            return repository.Get().ToList();
        }

        public List<Invoice> GetAllSpendedInvoices()
        {
            return repository.Get().Where(i=>i.IsSpended==true).ToList();
        }

        public List<Invoice> GetAllUnSpendedInvoices()
        {
            return repository.Get().Where(i=>i.IsSpended==false).ToList();
        }

        public List<Invoice> GetAllUserInvoices(User user)
        {
            return repository.Get().Where(i=>i.user == user).ToList();
        }

        public List<Invoice> GetAllHousingInvoices(Housing housing)
        {
            return repository.Get().Where(i=>i.Housing==housing).ToList();
        }
        public Invoice GetInvoiceById(int invoiceId)
        {
            return repository.Get().Where(i => i.Id == invoiceId).First();
        }

        public void Add(Invoice invoice)
        {
            invoice.IsSpended = false;
            repository.Add(invoice);
            unitOfWork.Commit();
        }

        public void Update(Invoice invoice)
        {
           repository.Update(invoice);
           unitOfWork.Commit();
        }

        public void Delete(Invoice invoice)
        {
            repository.Delete(invoice);
            unitOfWork.Commit();
        }
    }
}
