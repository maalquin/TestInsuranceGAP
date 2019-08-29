using Gap.Domain;
using Gap.WepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gap.WepApi.Common
{
    public static class EntityExtensions
    {
        public static WebApiUserModel ToModel(this GAPWebApiUser user)
        {
            return new WebApiUserModel
            {
                UserName = user.UserName,
                Password = user.Password
              
            };
        }

   
    }
}