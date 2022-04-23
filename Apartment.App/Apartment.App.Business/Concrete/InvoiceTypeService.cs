using System.Collections.Generic;
using System.Linq;
using Apartment.App.Business.Abstract;
using Apartment.App.DataAccessEntityFramework.Repository.Abstract;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Business.Concrete
{
    public class InvoiceTypeService : IinvoiceTypeService
    {
        private readonly IRepository<InvoiceType> repository;
        private readonly IUnitOfWork unitOfWork;
        public InvoiceTypeService(IRepository<InvoiceType> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public List<InvoiceType> getAllInvoiceTypes()
        {
            return repository.Get().ToList();
        }

        public InvoiceType GetInvoiceTypeById(int invoiceTypeId)
        {
            return repository.Get().Where(i => i.Id == invoiceTypeId).FirstOrDefault();
        }

        public bool InvoiceTypeIsThere(string invoiceTypeName)
        {
            return repository.Get().Where(i => i.TypeName == invoiceTypeName).FirstOrDefault() != null ? true : false;
        }

        public string InvoiceTypeName(InvoiceType invoiceType)
        {
            return repository.Get().Where(i => i.Id == invoiceType.Id).FirstOrDefault().TypeName;
        }

        public string InvoiceTypeUnit(InvoiceType invoiceType)
        {
            return repository.Get().Where(i => i.Id == invoiceType.Id).FirstOrDefault().TypeUnit;
        }

        public void Add(string invoiceTypeName, string invoiceTypeUnit)
        {
            var invoiceType = new InvoiceType
            {
                TypeName = invoiceTypeName,
                TypeUnit = invoiceTypeUnit
            };
            repository.Add(invoiceType);
            unitOfWork.Commit();
        }

        public void Update(int id,string invoiceTypeName, string invoiceTypeUnit)
        {
            var invoiceType = new InvoiceType
            {
                Id = id,
                TypeName = invoiceTypeName,
                TypeUnit = invoiceTypeUnit
            };
            repository.Update(invoiceType);
            unitOfWork.Commit();
        }

        public void Delete(InvoiceType invoiceType)
        {
            repository.Delete(invoiceType);
            unitOfWork.Commit();
        }
    }
}
