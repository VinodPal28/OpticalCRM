using OpticalCRM.Auth.Authentication;
using OpticalCRM.Auth.CustomeFilter;
using OpticalCRM.Auth.Token;
using OpticalCRM.Data.enums;
using OpticalCRM.Data.Services;
using OpticalCRM.DependencyResolution.Resources;
using OpticalCRM.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OpticalCRM.WebApi.Controllers
{
    
    [RoutePrefix("api/Frame")]
    public class FrameController : ApiController
    {
        private readonly IframeService _frameService;
        public FrameController(IframeService frameService)
        {
            _frameService = frameService;
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("addFrameDetails", Name = "addFrameDetails")]
        public HttpResponseMessage addFrameDetails(frameResource frameModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var result = _frameService.isAddFrameDetails(frameModel);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("getFrames", Name = "getFrames")]
        public HttpResponseMessage getFrames(frameResource frameModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var frames = _frameService.getFrameDetails(frameModel);
            if (frames != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, frames, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            //return null;
        }

        [HttpPost]
        [Route("refreshToken", Name = "refreshToken")]
        public HttpResponseMessage refreshToken(LoginResource model)
        {
            userAuthenticationResource usertoken = new userAuthenticationResource();
            usertoken.Token = TokenManager.GenerateToken(model.username);
            usertoken.RefreshToken = TokenManager.generateRefreshToken();
            return Request.CreateResponse(HttpStatusCode.OK, usertoken, Configuration.Formatters.JsonFormatter);
            
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("editFrameDetails", Name = "editFrameDetails")]
        public HttpResponseMessage editFrameDetails(frameResource frameModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var frames = _frameService.getFrameDetailsbyId(frameModel);
            if (frames != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, frames, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            return null;
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("updateFrameDetails", Name = "updateFrameDetails")]
        public HttpResponseMessage updateFrameDetails(frameResource frameModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var result = _frameService.isUpdated(frameModel);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("deleteFrameById", Name = "deleteFrameById")]
        public HttpResponseMessage deleteFrameById(frameResource frameModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var result = _frameService.isDeleted(frameModel);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("deactivateById", Name = "deactivateById")]
        public HttpResponseMessage deactivateById(frameResource frameModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            frameModel.flag = (int)Status.Deactive;
            bool result = _frameService.isStatus(frameModel);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("activateById", Name = "activateById")]
        public HttpResponseMessage activateById(frameResource frameModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            frameModel.flag = (int)Status.Active;
            bool result = _frameService.isStatus(frameModel);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}
