using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apartment.App.Business.DTO;
using Apartment.App.Domain.Entities.IdentityEntities;
using Apartment.App.Web.Models.UserViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Apartment.App.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private IMapper mapper;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var allUsers = userManager.Users.ToList();
            var model = new UserViewModel();
            
            foreach (var user in allUsers)
            {
                 bool IsRoleUser = userManager.IsInRoleAsync(user, "user").Result;
                 if (IsRoleUser || true)
                 {
                    model.Users.Add(new UserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        TrIdentityNumber = user.TrIdentityNumber,
                        HasCar = user.HasCar,
                        CarPlateNumber = user.CarPlateNumber,
                        UserIsAdmin = UserIsAdmin(user.TrIdentityNumber) ,
                    });
                }   
            }
            return View(model);
        }
        

        #region User Adding Admin Role

        [HttpGet]
        public IActionResult Add( )
        {
            return View();
        }
        
        [HttpPost]
        public async Task <IActionResult> Add(UserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.CreateAsync(new User
                {
                    UserName = model.User.FirstName + model.User.TrIdentityNumber,
                    
                    FirstName = model.User.FirstName,
                    LastName = model.User.LastName,
                    Email = model.User.Email,
                    PhoneNumber = model.User.PhoneNumber,
                    TrIdentityNumber = model.User.TrIdentityNumber,
                    HasCar = model.User.HasCar,
                    CarPlateNumber = model.User.CarPlateNumber,
                }, "Sifre123.");
                if (result.Succeeded)
                {
                     addRoleForUser(model.User.TrIdentityNumber, model.User.UserIsAdmin);
                     return RedirectToAction("Index");
                }
            }
            return View();
        }
        #endregion

        #region User Updating Admin Role

        [HttpGet]
        public IActionResult Update(string TrIdentityNumber)
        {
            var user = userManager.Users.Where(u => u.TrIdentityNumber == TrIdentityNumber).First();
            var model = new UserUpdateViewModel();
            model.user = new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                TrIdentityNumber = user.TrIdentityNumber,
                HasCar = user.HasCar,
                CarPlateNumber = user.CarPlateNumber,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserIsAdmin = UserIsAdmin(user.TrIdentityNumber)
            };
            userManager.UpdateAsync(user);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Users.Where(u => u.TrIdentityNumber == model.TrIdentityNumber).First();
                user.CarPlateNumber = model.CarPlateNumber;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.HasCar = model.HasCar;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                if (UserIsAdmin(user.TrIdentityNumber) != model.UserIsAdmin)
                {
                    if (model.UserIsAdmin)
                    {
                        addRoleForUser(user.TrIdentityNumber, model.UserIsAdmin);
                    }
                    else
                    {
                        userManager.RemoveFromRoleAsync(user, "admin").Wait();
                    }
                }
                
                //update
                userManager.UpdateAsync(user);
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        #endregion



        #region userFunctions


        public void addRoleForUser(string TrIdentityNumber, bool isAdmin)
        {
            var user = userManager.Users.Where(u => u.TrIdentityNumber == TrIdentityNumber).First();
            if (isAdmin)
            {
                userManager.AddToRoleAsync(user, "admin").Wait();
            }
            userManager.AddToRoleAsync(user, "user").Wait();
        }

        public bool UserIsAdmin(string TrIdentityNumber)
        {
            var user = userManager.Users.Where(u => u.TrIdentityNumber == TrIdentityNumber).First();
            var roles = userManager.GetRolesAsync(user).Result;
            if (roles.Contains("Admin"))
            {
                return true;
            }
            return false;
        }
     
        #endregion
    }
}
