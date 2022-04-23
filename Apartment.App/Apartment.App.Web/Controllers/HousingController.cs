using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Apartment.App.Business.Abstract;
using Apartment.App.Business.DTO;
using Apartment.App.Domain.Entities;
using Apartment.App.Domain.Entities.IdentityEntities;
using Apartment.App.Web.Enums;
using Apartment.App.Web.Models.HousingViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apartment.App.Web.Controllers
{
    [Authorize]
    public class HousingController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly IFloorService floorService;
        private readonly IBlockService blockService;
        private readonly IHousingService housingService;
        private readonly IMapper mapper;
        private User currentUser = null;
        public HousingController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IBlockService blockService, IFloorService floorService, IHousingService housingService, IMapper mapper)
        {
            this.userManager = userManager;
            this.housingService = housingService;
            this.roleManager = roleManager;
            this.floorService = floorService;
            this.blockService = blockService;
            this.signInManager = signInManager;
            this.mapper = mapper;
            currentUser = userManager.FindByNameAsync(signInManager.Context.User.Identity.Name).Result;
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
        {
            var blocksassd = blockService.GetAll();
            var floosrse = floorService.GetAll();

            var model = new HousingViewModel();
           
            model.isUserAdmin = userManager.GetRolesAsync(currentUser).Result.Contains(Roles.Admin.ToString());
            var housings = new List<Housing>();
            housings = model.isUserAdmin ? housingService.GetAllHousing() : housingService.GetHousingsByUserId(currentUser.Id);
            foreach (var housing in housings)
            {
                model.HousingList.Add(new HousingDto
                {
                    Id = housing.Id,
                    IsEmpty = housing.IsEmpty,
                    IsHomeowner = housing.IsHomeowner,
                    BlockNumber = housing.Floor.Block.BlockNumber,
                    FloorNumber = housing.Floor.FloorNumber,
                    ApartmentNumber = housing.ApartmentNumber,
                    ApartmentSizeInfo = housing.ApartmentSizeInfo,
                });
            }
            return View(model);
        }

        #region Ev/Daire Ekleme

        [HttpGet]
        public IActionResult Add(int floorId)
        {

            var blocks = blockService.GetAll();
            var floors = floorService.GetAll();
            //kat bilgileri hazırlanmış şekilde model oluştur gönder

            var aptNumber = housingService.GetHousingCountByFloorId(floorId) + 1;

            //mevcut kat bilgileri
            var floor = floorService.GetById(floorId);

            var model = new HousingAddViewModel
            {
                HousingHirerTcIdentityNumber = "",
                IsEmpty = false,
                IsHomeowner = false,
                BlockNumber = floor.Block.BlockNumber,
                FloorNumber = floor.FloorNumber,
                ApartmentNumber = aptNumber,
                ApartmentSizeInfo = "",
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(HousingAddViewModel model)
        {
            var users = userManager.Users.ToList();
            if (!users.Where(x => x.TrIdentityNumber == model.HousingHirerTcIdentityNumber).Any() && model.HousingHirerTcIdentityNumber != null)
            {
                ModelState.AddModelError("HousingHirerTcIdentityNumber", "Bu TC Kimlik Numarasına sahip bir kullanıcı bulunmaktadır.");
            }
            if (ModelState.IsValid)
            {
                var housing = new Housing
                {
                    ApartmentNumber = model.ApartmentNumber,
                    ApartmentSizeInfo = model.ApartmentSizeInfo,
                    Floor = floorService.GetById(FloorIdByBlockAndFloorNumber(model.BlockNumber, model.FloorNumber)),
                };
                if (model.IsEmpty)
                {
                    housing.IsEmpty = false;
                    housing.IsHomeowner = model.IsHomeowner;
                    housing.User = userManager.Users.Where(x => x.TrIdentityNumber == model.HousingHirerTcIdentityNumber).FirstOrDefault();
                }
                else
                {
                    housing.IsEmpty = true;
                    housing.IsHomeowner = false;
                    housing.User = null;
                }
                housingService.Add(housing);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion

        #region Kiracı Ev Sahibi Ekleme

        [HttpGet]
        public IActionResult AddHirer(int housingId)
        {
            var blocks = blockService.GetAll();
            var floors = floorService.GetAll();

            var housing = housingService.GetHousingById(housingId);

            var model = new HousingAddViewModel
            {
                Id = housingId,
                HousingHirerTcIdentityNumber = "",
                IsEmpty = true,
                IsHomeowner = false,
                BlockNumber = housing.Floor.Block.BlockNumber,
                FloorNumber = housing.Floor.FloorNumber,
                ApartmentNumber = housing.ApartmentNumber,
                ApartmentSizeInfo = housing.ApartmentSizeInfo,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddHirer(HousingAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (userManager.Users.Where(x => x.TrIdentityNumber == model.HousingHirerTcIdentityNumber).Any() == false)
            {
                ModelState.AddModelError("HousingHirerTcIdentityNumber", "Bu TC Kimlik Numarasına sahip bir kullanıcı bulunmaktadır.");
                return View(model);
            }

            var housing = housingService.GetHousingById(model.Id);
            housing.IsEmpty = false;
            housing.IsHomeowner = model.IsHomeowner;
            housing.User = userManager.Users.Where(x => x.TrIdentityNumber == model.HousingHirerTcIdentityNumber).FirstOrDefault();
            housingService.Update(housing);
            return RedirectToAction("Index", "Housing");
        }

        #endregion

        #region Remove Hirer  //YAPILMADI
        //eğer ev üzeirnde ödenmemiş fatura var ise kullanıcıyı düşürmez

        #endregion

        #region Update //YAPILMADI

        [HttpGet]
        public IActionResult Update(HousingAddViewModel model)
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Update(HousingAddViewModel model)
        //{
        //    return View();
        //}
        #endregion
        
        #region Delete //YAPILMADI

        [HttpPost]
        public IActionResult DeleteHousing()
        {
            return View();
        }

        #endregion

        #region Fonksiyonlar
        private int FloorIdByBlockAndFloorNumber(int blockNumber, int floorNumber)
        {
            var blocks = blockService.GetAll();
            var floors = floorService.GetAll();
            return floorService
                .GetAllByBlockId(blockService.GetAll().Where(b => b.BlockNumber == blockNumber && b.IsDeleted == false)
                    .First().Id).Where(f => f.FloorNumber == floorNumber && f.IsDeleted == false).First().Id;
        }



        #endregion
    }
}
