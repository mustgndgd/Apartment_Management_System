using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apartment.App.Business.Abstract;
using Apartment.App.DataAccessEntityFramework.Repository.Abstract;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Business.Concrete
{
    public class FloorService:IFloorService
    {
        private readonly IRepository<Floor> repository;
        private readonly IUnitOfWork unitOfWork;
        public FloorService(IRepository<Floor> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public List<Floor> GetAll()
        {
            return  repository.Get().ToList();
        }

        public List<Floor> GetAllByBlockId(int blockId)
        {
            return repository.Get().Where(f=>f.Block.Id==blockId).ToList();
        }

        public Floor GetById(int id)
        {
            return repository.Get().Where(f=>f.Id==id).First();
        }

        public int GetBlockIdByFloorId(int id)
        {
            return repository.Get().Where(x=>x.Block.Id==id).First().Block.Id;
        }

        public void Add(Floor entity)
        {
            repository.Add(entity);
            unitOfWork.Commit();
        }

        public void Update(Floor entity)
        {
            repository.Update(entity);
            unitOfWork.Commit();
        }

        public void Delete(Floor entity)
        {
            repository.Delete(entity);
            unitOfWork.Commit();
        }
    }
}
