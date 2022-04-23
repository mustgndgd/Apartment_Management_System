using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Business.Abstract
{
    public interface IinvoiceTypeService
    {
        List<InvoiceType> getAllInvoiceTypes();
        InvoiceType GetInvoiceTypeById(int invoiceTypeId);
        bool InvoiceTypeIsThere(string invoiceTypeName);
        string InvoiceTypeName(InvoiceType invoiceType);
        string InvoiceTypeUnit(InvoiceType invoiceType);
        void Add(string invoiceTypeName, string invoiceTypeUnit);
        void Update(int id,string invoiceTypeName, string invoiceTypeUnit);
        void Delete(InvoiceType invoiceType);
    }
}
