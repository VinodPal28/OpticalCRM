using AutoMapper;
using OpticalCRM.DependencyResolution.Resources;
using OpticalCRM.EntityFramework.Entity;
using OpticalCRM.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<List<Login>, List<LoginResource>>();
            CreateMap<List<userMaster>, List<userMasterResource>>();
        }
    }
}
