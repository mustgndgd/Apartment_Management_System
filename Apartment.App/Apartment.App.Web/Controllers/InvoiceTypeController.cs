using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apartment.App.Business.Abstract;
using Apartment.App.Business.Concrete;
using Apartment.App.Business.DTO;
using Apartment.App.Domain.Entities;
using Apartment.App.Web.Models;
using Apartment.App.Web.Models.InvoiceTypeModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apartment.App.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InvoiceTypeController : Controller
    {
        private readonly IinvoiceTypeService invoiceTypeService;
        private readonly IMapper mapper;
        public InvoiceTypeController(IinvoiceTypeService invoiceTypeService, IMapper mapper)
        {
            this.invoiceTypeService = invoiceTypeService;
            this.mapper = mapper;
        }
       
        [HttpGet]
        public IActionResult Index()
        {
            var types = invoiceTypeService.getAllInvoiceTypes();
            var model = new InvoiceTypeViewModel
            {
                InvoiceTypes = new List<InvoiceTypeDto>()
            };
            foreach (var item in types)
            {
                model.InvoiceTypes.Add(new InvoiceTypeDto()
                {
                    Id=item.Id,
                    Name = item.TypeName,
                    Unit = item.TypeUnit
                });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Manage( int id )
        {
            var model = new InvoiceTypeManageModel();
            if ( id != 0 )
            {
                var type = invoiceTypeService.GetInvoiceTypeById(id);
                model.Id = type.Id;
                model.Name = type.TypeName;
                model.Unit = type.TypeUnit;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Manage(InvoiceTypeManageModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0) 
                {
                    invoiceTypeService.Add(model.Name, model.Unit);
                }
                else
                {
                    invoiceTypeService.Update(model.Id, model.Name, model.Unit);
                }
                return  RedirectToAction("Index");
            }
            return View();
        }
    }
}
