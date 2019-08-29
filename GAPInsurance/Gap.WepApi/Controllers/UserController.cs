using Gap.DataAccess;
using Gap.DataAccess.Repositories;
using Gap.Domain;
using Gap.WepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gap.WepApi.Controllers
{
    
    public class UserController : ApiController
    {
        private readonly IRepository<GAPWebApiUser> _repository;
        private readonly IWebTokenUserRepository<GAPWebAPIUserToken> _webTokenRepository;

        public UserController(IRepository<GAPWebApiUser> repository, IWebTokenUserRepository<GAPWebAPIUserToken> webTokenRepository)
        {
            _repository = repository;
            _webTokenRepository = webTokenRepository;
        }

    
        [HttpPost]
        public HttpResponseMessage Register(WebApiUserModel userModel)
        {
            var user =  _repository.GetByNamePassword(userModel.UserName, userModel.Password);

            if (user.Guid != null)
            {
                var webToken = _webTokenRepository.GetbyGuid(user.Guid);
                if (_webTokenRepository.ExpiredTokenKey(webToken.FirstOrDefault().TokenId))
                {
                    if (_webTokenRepository.Delete(webToken.FirstOrDefault().TokenId))
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, "User not found.");

                    Guid tokenReturn = _webTokenRepository.InsertOrUpdate(user.Guid);

                    return Request.CreateResponse(HttpStatusCode.OK, tokenReturn);
                } 
               
            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized, "User not found.");
        }

        private GAPWebAPIUserToken CreateToken(Guid userGuid)
        {
            var expiredTime = DateTime.Now.AddMinutes(5);
            Guid tokenNew = Guid.NewGuid();
            GAPWebAPIUserToken token = new GAPWebAPIUserToken();
            token.TokenId = tokenNew;
            token.Guid = Guid.NewGuid();
            token.TokenExpireDateTime = expiredTime;
            token.WebAPIUser_Guid = userGuid;
            return token;
        }
    }
}
