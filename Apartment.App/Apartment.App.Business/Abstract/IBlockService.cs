using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Business.Abstract
{
    public interface IBlockService
    {
        List<Block> GetAll();
        Block GetById(int id);
        void Add(Block entity);
        void Update(Block entity);
        void Delete(Block entity);
    }
}
