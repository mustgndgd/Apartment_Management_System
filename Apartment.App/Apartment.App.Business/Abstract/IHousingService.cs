using System;
using System.Collections.Generic;
using System.Text;
using Apartment.App.Domain.Entities;
using Apartment.App.Domain.Entities.IdentityEntities;

namespace Apartment.App.Business.Abstract
{
    public interface IHousingService
    {
        List<Housing> GetAllHousing();
        List<Housing> GetAllActiveHousings();
        Housing GetHousingById(int housingId);
        Housing GetHousingByUserId(string userId);
        List<Housing> GetHousingByBlockId(int blockId);
        List<Housing> GetHousingsByUserId(string userId);
        string GetHousingAddressByHousingId(int housingId);
        string GetUserIdByHousingId(int hosungiId);
        string GetUserTrIdentityByHousingId(int hosungiId);
        int GetHousingCountByFloorId(int floorId);
        void Add(Housing housing);
        void Update(Housing housing);
        void Delete(Housing housing);

    }
}
