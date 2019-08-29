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
        public async Task<IHttpActionResult> Login(WebApiUserModel userModel)
        {
            var user = await _repository.GetByNamePassword(userModel.UserName, userModel.Password);

            if (user.Guid != null)
            {
                var webToken = _webTokenRepository.GetbyGuid(user.Guid);

                return Ok();
            }

            else return BadRequest();
        }
    }
}
