using System.Linq;
using Apartment.App.Business.Abstract;
using Apartment.App.Business.DTO;
using Apartment.App.Domain.Entities;
using Apartment.App.Web.Models.FloorModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apartment.App.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FloorController : Controller
    {
        private IFloorService floorsService;
        private IBlockService blockService;
        private IMapper mapper;
        public FloorController(IFloorService floorservice, IBlockService blokService, IMapper mapper)
        {
            this.floorsService = floorservice;
            this.blockService = blokService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var model = new FloorViewModel();
            var floors = floorsService.GetAll();
            foreach (var floor in floors)
            {
                model.Floors.Add(mapper.Map<FloorDto>(floor));
            }
            return RedirectToAction("Index","Block");
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var lastFloor = floorsService.GetAllByBlockId(id).OrderByDescending(x => x.Id).FirstOrDefault();
            var newFloor = new FloorDto();
            if (lastFloor == null)
            {
                newFloor.BlockId = id;
                newFloor.FloorNumber = 0;
            }
            else
            {
                newFloor.BlockId = id;
                newFloor.FloorNumber = lastFloor.FloorNumber + 1;
            }
            floorsService.Add(new Floor
            {
                FloorNumber = newFloor.FloorNumber,
                Block = blockService.GetById(newFloor.BlockId),
            });
            return RedirectToAction("Index");
        }

    }
}
