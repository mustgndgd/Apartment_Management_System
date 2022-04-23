using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apartment.App.Business.Abstract;
using Apartment.App.DataAccessEntityFramework.Repository.Abstract;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Business.Concrete
{
    public class BlockService:IBlockService
    {
        private readonly IRepository<Block> repository;
        private readonly IUnitOfWork unitOfWork;
        public BlockService(IRepository<Block> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public List<Block> GetAll()
        {
            return repository.Get().ToList();
        }

        public Block GetById(int id)
        {
            return repository.Get().Where(b=>b.Id==id).First();    
        }

        public void Add(Block entity)
        {
            repository.Add(entity);
            unitOfWork.Commit();
        }

        public void Update(Block entity)
        {
            repository.Update(entity);
            unitOfWork.Commit();
        }

        public void Delete(Block entity)
        {
            repository.Delete(entity);
            unitOfWork.Commit();
        }
    }
}
