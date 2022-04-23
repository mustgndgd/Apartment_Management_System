using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;
using Apartment.App.Domain.Entities.IdentityEntities;

namespace Apartment.App.Business.Abstract
{
    public interface IinvoiceService
    {
        List<Invoice> GetAllInvocies();
        List<Invoice> GetAllSpendedInvoices();
        List<Invoice> GetAllUnSpendedInvoices();
        List<Invoice> GetAllUserInvoices(User user);
        List<Invoice> GetAllHousingInvoices(Housing housing);
        Invoice GetInvoiceById(int invoiceId);
        void Add(Invoice invocie);
        void Update(Invoice invoice);
        void Delete(Invoice invoice);
    }
}
