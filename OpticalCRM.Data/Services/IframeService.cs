using OpticalCRM.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.Data.Services
{
    public interface IframeService
    {
        bool isAddFrameDetails(frameResource model);        
        List<frameResource> getFrameDetails(frameResource frameModel);
        List<frameResource> getFrameDetailsbyId(frameResource frameModel);
        bool isUpdated(frameResource model);
        bool isDeleted(frameResource model);
        bool isStatus(frameResource model);
    }
}
