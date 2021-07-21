using OpticalCRM.Data.DomainContext;
using OpticalCRM.Data.enums;
using OpticalCRM.EntityFramework.Entity;
using OpticalCRM.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace OpticalCRM.Data.Services.Implementations
{
    public class frameService : IframeService
    {
        private readonly IOpticalCRMDomainContext _opticalCRMDomainContext;

        public frameService(IOpticalCRMDomainContext opticalCRMDomainContext)
        {
            _opticalCRMDomainContext = opticalCRMDomainContext;
        }

        public bool isAddFrameDetails(frameResource modelDto)
        {

            var entity = new frame
            {
                productCode = modelDto.productCode,
                name = modelDto.name,
                color = modelDto.color,
                size = modelDto.size,
                type = modelDto.type,
                shape = modelDto.shape,
                material = modelDto.material,
                company = modelDto.company,
                gender = modelDto.gender,
                trackInventory = modelDto.trackInventory,
                allowNegativeInventory = modelDto.allowNegativeInventory,
                purchaseBasePrice = modelDto.purchaseBasePrice,
                purchasePrice = modelDto.purchasePrice,
                retailPrice = modelDto.retailPrice,
                flag = (int)Status.Active,
                createdby = modelDto.createdby,
                createdDate = DateTime.Now
            };
            _opticalCRMDomainContext.Add(entity);
            if (_opticalCRMDomainContext.SaveChanges() == 1) return true;
            return false;
        }

        public List<frameResource> getFrameDetails(frameResource modelDto)
        {
            var data = _opticalCRMDomainContext.frames
                .Where(x => x.createdby == modelDto.createdby)
                .Select(x => new frameResource
                {
                    Id = x.Id,
                    productCode = x.productCode,
                    name = x.name,
                    purchasePrice = x.purchasePrice,
                    retailPrice = x.retailPrice,
                    flag = x.flag,
                    createdDate = x.createdDate,
                    updatedDate = x.updatedDate
                }).OrderBy(x => x.Id).ToList();
            // .Skip(0)
            //.Take(10).ToList();
            return data;
        }

        public List<frameResource> getFrameDetailsbyId(frameResource modelDto)
        {
            var data = _opticalCRMDomainContext.frames
                .Where(x => x.Id == modelDto.Id)
                .Select(x => new frameResource
                {
                    Id = x.Id,
                    productCode = x.productCode,
                    name = x.name,
                    color = x.color,
                    size = x.size,
                    type = x.type,
                    shape = x.shape,
                    material = x.material,
                    company = x.company,
                    gender = x.gender,
                    trackInventory = x.trackInventory,
                    allowNegativeInventory = x.allowNegativeInventory,
                    purchasePrice = x.purchasePrice,
                    retailPrice = x.retailPrice,
                    flag = x.flag,
                    createdDate = x.createdDate,
                    updatedDate = x.updatedDate
                }).OrderBy(x => x.Id).ToList();
            // .Skip(0)
            //.Take(10).ToList();
            return data;
        }

        public bool isUpdated(frameResource modelDto)
        {
            frame entity = (from f in _opticalCRMDomainContext.frames
                            where f.productCode == modelDto.productCode
                            select f).FirstOrDefault();
            if (entity != null)
            {
                entity.productCode = modelDto.productCode;
                entity.name = modelDto.name;
                entity.color = modelDto.color;
                entity.size = modelDto.size;
                entity.type = modelDto.type;
                entity.shape = modelDto.shape;
                entity.material = modelDto.material;
                entity.company = modelDto.company;
                entity.gender = modelDto.gender;
                entity.trackInventory = modelDto.trackInventory;
                entity.allowNegativeInventory = modelDto.allowNegativeInventory;
                entity.purchaseBasePrice = modelDto.purchaseBasePrice;
                entity.purchasePrice = modelDto.purchasePrice;
                entity.retailPrice = modelDto.retailPrice;
                entity.updatedby = modelDto.updatedby;
                entity.updatedDate = DateTime.Now;
            }
            _opticalCRMDomainContext.Update(entity);
            if (_opticalCRMDomainContext.SaveChanges() == 1) return true;
            return false;
        }

        public bool isDeleted(frameResource modelDto)
        {
            var data = _opticalCRMDomainContext.frames.SingleOrDefault(x => x.productCode == modelDto.productCode);
            if (data == null) return false;
            _opticalCRMDomainContext.Delete(data);
            if (_opticalCRMDomainContext.SaveChanges() == 1) return true;
            return false;
        }

        public bool isStatus(frameResource modelDto)
        {
            var entity = (from f in _opticalCRMDomainContext.frames
                            where f.Id == modelDto.Id
                            select f).FirstOrDefault();
            if (entity != null)
            {
                entity.flag = modelDto.flag;
            }
            _opticalCRMDomainContext.Update(entity);
            if (_opticalCRMDomainContext.SaveChanges() == 1) return true;
            return false;
        }

    }
}
