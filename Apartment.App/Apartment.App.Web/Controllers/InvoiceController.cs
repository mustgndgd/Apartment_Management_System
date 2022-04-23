using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Apartment.App.Business.Abstract;
using Apartment.App.Business.Concrete;
using Apartment.App.Business.DTO;
using Apartment.App.Domain.Entities;
using Apartment.App.Domain.Entities.IdentityEntities;
using Apartment.App.Web.Background;
using Apartment.App.Web.Data;
using Apartment.App.Web.Enums;
using Apartment.App.Web.Models;
using Apartment.App.Web.Models.InvoiceModels;
using Apartment.App.Web.Models.MailModels;
using Apartment.App.Web.PaymentApiService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Flurl;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Apartment.App.Web.Controllers
{
    public class InvoiceController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly IinvoiceService invoiceService;
        private readonly IHousingService housingService;
        private readonly IinvoiceTypeService invoiceTypeService;
        private readonly IFloorService floorService;
        private readonly IBlockService blockService;
        private readonly IBackgroundQueue<Mail> queue;
        private readonly IMapper mapper;
        private User currentUser = null;
        public InvoiceController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IinvoiceService invoiceService, IHousingService housingService, IinvoiceTypeService invoiceTypeService, IFloorService floorService, IBlockService blockService, IBackgroundQueue<Mail> queue, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.housingService = housingService;
            this.invoiceService = invoiceService;
            this.invoiceTypeService = invoiceTypeService;
            this.floorService = floorService;
            this.blockService = blockService;
            this.queue = queue;
            this.mapper = mapper;
            currentUser = userManager.FindByNameAsync(signInManager.Context.User.Identity.Name).Result;
        }
        public IActionResult Index(int id = 0)
        {
            if (currentUser != null)
            {
                var users = userManager.Users.ToList();
                var housings = housingService.GetAllHousing();
                var model = new InvoiceViewModel();
                var invoices = new List<Invoice>();
                var floors = floorService.GetAll();
                var blocks = blockService.GetAll();
                var invoiceTypes = invoiceTypeService.getAllInvoiceTypes();
                model.isUserAdmin = getCurrentUserRole() == Roles.Admin ? true : false;
                if (model.isUserAdmin && id == 0)
                {
                    invoiceService.GetAllInvocies().ToList().ForEach(x => invoices.Add(x));
                }
                else if (model.isUserAdmin && id != 0)
                {
                    invoiceService.GetAllInvocies().Where(i => i.Housing.Id == id).ToList().ForEach(i => invoices.Add(i));
                }
                else
                {
                    invoices = invoiceService.GetAllUserInvoices(currentUser);

                }

                foreach (var invoice in invoices)
                {
                    model.Invoices.Add(new InvoiceModel
                    {
                        Id = invoice.Id,
                        housingId = invoice.Housing.Id,
                        InvoiceOwnerTrIdentity = invoice.user.TrIdentityNumber,
                        InvoiceOwnerName = invoice.user.FirstName + " " + invoice.user.LastName,
                        housingAdress = " Blok:" + invoice.Housing.Floor.Block.BlockNumber + " Kat:" + invoice.Housing.Floor.FloorNumber + " No:" + invoice.Housing.ApartmentNumber,
                        invoiceType = new InvoiceTypeDto { Id = invoice.InvoiceType.Id, Name = invoice.InvoiceType.TypeName, Unit = invoice.InvoiceType.TypeUnit },
                        IsSpended = invoice.IsSpended,
                        TotalDay = invoice.TotalDay,
                        InvoiceAmountOfUse = invoice.InvoiceAmountOfUse,
                        InvoiceUnitPrice = invoice.InvoiceUnitPrice,
                        InvoicePrice = invoice.InvoicePrice,
                        CreatedDate = invoice.CreatedDate,
                        LastSpendDate = invoice.LastSpendDate
                    });
                }
                return View(model);
            };
            return RedirectToAction("Index", "Home");
        }

        #region  Fatura ekleme 

        [HttpGet]
        public IActionResult Add(int housingId)  //fatura sadece dolu bir eve kesilebilir.
        {
            var floors = floorService.GetAll();
            var blocks = blockService.GetAll();
            var housings = housingService.GetAllHousing().Where(x => x.IsEmpty == false).ToList();
            var users = userManager.Users.ToList();


            ViewData["InvoiceTypes"] = invoiceTypeService.getAllInvoiceTypes();

            var model = new InvoiceAddModel();

            model.housingId = housingId;
            model.InvoiceOwnerTrIdentity = users.Where(x => x.Id == housings.Find(h => h.Id == model.housingId).User.Id).First().TrIdentityNumber;
            model.housingOwner = users.Where(x => x.TrIdentityNumber == model.InvoiceOwnerTrIdentity).First().FirstName + " " + users.Where(x => x.TrIdentityNumber == model.InvoiceOwnerTrIdentity).First().LastName;
            model.housingAddress = housingService.GetHousingAddressByHousingId(model.housingId);
            model.InvoiceAmountOfUse = "0";
            model.InvoicePrice = "0";
            model.InvoiceTypeId = -1;
            model.InvoiceUnitPrice = "0";
            model.TotalDay = 0;

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(InvoiceAddModel model)
        {
            var invoiceTypes = invoiceTypeService.getAllInvoiceTypes();
            if (ModelState.IsValid)
            {
                invoiceService.Add(new Invoice
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = currentUser.Id,
                    CreatedDate = DateTime.Now,
                    Housing = housingService.GetHousingById(model.housingId),
                    user = userManager.Users.Where(x => x.TrIdentityNumber == model.InvoiceOwnerTrIdentity).First(),
                    InvoiceAmountOfUse = Convert.ToDouble(model.InvoiceAmountOfUse.Split('.')[0] + "," + model.InvoiceAmountOfUse.Split('.')[1]),
                    InvoicePrice = Convert.ToDouble(model.InvoicePrice.Split('.')[0] + "," + model.InvoicePrice.Split('.')[1]),
                    InvoiceUnitPrice = Convert.ToDouble(model.InvoiceUnitPrice.Split('.')[0] + "," + model.InvoiceUnitPrice.Split('.')[1]),
                    IsDeleted = false,
                    IsSpended = false,
                    InvoiceType = invoiceTypeService.GetInvoiceTypeById(model.InvoiceTypeId),
                    TotalDay = model.TotalDay,
                    LastUpdatedAt = DateTime.Now,
                    LastUpdatedBy = currentUser.Id,
                    LastSpendDate = DateTime.Now.AddDays(model.TotalDay)
                });
                return RedirectToAction("Index", "Invoice", 0);
            }
            ViewData["InvoiceTypes"] = invoiceTypeService.getAllInvoiceTypes();
            return View();
        }
        #endregion


        #region Fatura Ödeme işlemleri // YAPILMADI
        [HttpGet]
        public IActionResult Payment(int id)
        {
            var housings = housingService.GetAllHousing();
            var invoiceTypes = invoiceTypeService.getAllInvoiceTypes();
            var floors = floorService.GetAll();
            var blocks = blockService.GetAll();
            var users = userManager.Users.ToList();
            var invoice = invoiceService.GetInvoiceById(id);
            var model = new InvoicePayViewModel();

            model.InvoiceId = id;
            model.InvoiceOwnerTcIdentityNumber = invoice.user.TrIdentityNumber;
            model.CreditCardSecurtiyNumber = "";
            model.CreditCardLastUseableDateMonth = 0;
            model.CreditCardLastUseableDateYear = 0;
            model.CreditCardOwnerName = "";
            model.CreditCardNumber = "";
            model.InvoicePrice = invoice.InvoicePrice.ToString();
            model.InvoiceAddress = housingService.GetHousingAddressByHousingId(invoice.Housing.Id);
            model.InvoiceOwnerFullName = invoice.user.FirstName + " " + invoice.user.LastName;
            model.InvoiceDetail = invoice.InvoiceType.TypeName + " : " + invoice.InvoiceAmountOfUse.ToString() + " " + invoice.InvoiceType.TypeUnit.ToString();
            ViewData["Months"] = Consts.MonthsList;
            ViewData["Years"] = Consts.YearsList;

            return View(model);
        }
        [HttpPost]
        public IActionResult Payment(InvoicePayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Months"] = Consts.MonthsList;
                ViewData["Years"] = Consts.YearsList;
                return View(model);
            }
            var invoiceRecord = new PaymentModel
            {
                invoicePrice = model.InvoicePrice.ToString(),
                invoiceId = model.InvoiceId.ToString(),
                cardNumber = model.CreditCardNumber.ToString(),
                cardOwnerName = model.CreditCardOwnerName.ToString(),
                cardSecurityNumber = model.CreditCardSecurtiyNumber.ToString(),
                cardLastUsableDate = model.CreditCardLastUseableDateMonth.ToString() + "/" + model.CreditCardLastUseableDateYear.ToString(),
                invoiceOwnerTrIdentityNumber = model.InvoiceOwnerTcIdentityNumber.ToString(),
            };
            var result = PaymentService.Pay(invoiceRecord);
            if (result == "-1")
            {
                ViewData["Months"] = Consts.MonthsList;
                ViewData["Years"] = Consts.YearsList;
                ModelState.AddModelError("CreditCardNumber", "Kart numarası hatalı");
                return View(model);
            }
            var invoice = invoiceService.GetInvoiceById(model.InvoiceId);
            invoice.IsSpended = true;
            invoice.InvoicePaymentRecordId = result;
            invoiceService.Update(invoice);
            return RedirectToAction("Index", "Invoice");
        }

        #endregion

        #region Fatura güncelleme // YAPILMADI
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }
        //[Authorize(Roles = "admin")]
        //[HttpPost]
        //public IActionResult Update()
        //{
        //    return View();
        //}
        #endregion

        #region Mail send operation

        public IActionResult SendAllInvoicesToOwners()
        {
            var users = userManager.Users.ToList();
            var housings = housingService.GetAllHousing();
            var invoiceTypes = invoiceTypeService.getAllInvoiceTypes();

            var unPayedInvoices = invoiceService.GetAllInvocies().Where(x => x.IsSpended == false).ToList();
            try
            {
                foreach (var invoice in unPayedInvoices)
                {
                    var mail = new Mail();
                    mail.To = users.Where(x => x.TrIdentityNumber == invoice.user.TrIdentityNumber).First().Email;
                    mail.Body = invoice.InvoiceType.TypeName + "  Faturanızın ödemeniz gerekmektedir. Ödemenizi yapmak için aşağıdaki linke tıklayınız. " + "http://localhost:5000/Invoice/Payment/" + invoice.Id;
                    mail.Subject = "Fatura Ödeme";

                    queue.Enqueue(mail);
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        #endregion

        #region Fatura Ödeme bilgileri gösterme  //YAPILMADI

        [HttpGet]
        public IActionResult PaymentDetail(int id)
        {
            var invoice = invoiceService.GetInvoiceById(id);
            var record = PaymentService.GetPayment(invoice.InvoicePaymentRecordId);
            var model = new PaymentRecordiewModel
            {
                record = record,
            };
            return View(model);
        }
        #endregion

        #region Metotlar

        public Roles getCurrentUserRole()
        {
            IList<string> roles = userManager.GetRolesAsync(currentUser).Result;
            if (roles.Contains(Roles.Admin.ToString()))
            {
                return Roles.Admin;
            }
            return Roles.User;
        }

        #endregion
    }
}
