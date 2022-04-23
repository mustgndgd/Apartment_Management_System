using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apartment.App.Business.Abstract;
using Apartment.App.Business.Concrete;
using Apartment.App.Domain.Entities;
using Apartment.App.Domain.Entities.IdentityEntities;
using Apartment.App.Web.Enums;
using Microsoft.AspNetCore.Identity;
namespace Apartment.App.Web.Data
{
    public class ContextSeed
    {
        public static async Task SeedRoleAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));  await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new User
            {
                UserName = "superadmin",
                Email = "superadmin@superadmin.com",
                FirstName = "super",
                LastName = "admin",
                TrIdentityNumber = "12345678900",
                PhoneNumber = "12345678912",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Admin123.");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
                }
            }
        }
        public static void  SeedInvoiceType(IinvoiceTypeService invoiceTypeService)
        {
            var types = new List<InvoiceType>
            {
                new InvoiceType {TypeName = "Aidat", TypeUnit = "Gün"},
                new InvoiceType {TypeName = "Elektrik", TypeUnit = "KwH"},
                new InvoiceType {TypeName = "Su", TypeUnit = "m³"},
                new InvoiceType {TypeName = "Doğalgaz", TypeUnit = "m³"}
            };
            foreach (var type in types)
            {
                if (!invoiceTypeService.InvoiceTypeIsThere(type.TypeName)) {
                    invoiceTypeService.Add(type.TypeName,type.TypeUnit);
                }
            }   
        }
        public static void SeedAddBlocks(IBlockService blockService)
        {
            var blocks = new List<Block>
            {
                new Block {BlockNumber = 1, Name = "A"},
                new Block {BlockNumber = 2, Name = "B"},
            };
            foreach (var block in blocks)
            {
                if (! blockService.GetAll().Where(b => b.BlockNumber == block.BlockNumber).Any())
                {
                    blockService.Add(block);
                }
            }
        }

        public static void SeedAddFloors(IFloorService floorService,IBlockService blockService)
        {
            var blocks = blockService.GetAll();

            foreach (var block in blocks)
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (!floorService.GetAll().Any(f => f.FloorNumber == i && f.Block.Id == block.Id))
                    {
                        floorService.Add(new Floor { Block = block, FloorNumber = i });
                    }
                }
            }
        }

    }
}