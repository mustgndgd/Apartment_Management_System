using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Business.Abstract
{
    public interface IFloorService
    {
        List<Floor> GetAll();
        List<Floor> GetAllByBlockId(int blockId);
        Floor GetById(int id);
        int GetBlockIdByFloorId(int id);
        void Add(Floor entity);
        void Update(Floor entity);
        void Delete(Floor entity);
    }
}
