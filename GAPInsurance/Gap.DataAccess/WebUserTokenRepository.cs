using Gap.DataAccess.Repositories;
using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess
{
    public class WebUserTokenRepository : IWebTokenUserRepository<GAPWebAPIUserToken>
    {
     

        public IEnumerable<GAPWebAPIUserToken> GetbyGuid(Guid userGuid)
        {
            using (var context = new GapContext())
            {
                return context.GAPWebAPIUserToken
                                    .AsNoTracking().Where(x => x.WebAPIUser_Guid == userGuid).ToList();
                                    
            }
        }

        public Guid InsertOrUpdate(Guid userGuid)
        {

            var userToken = CreateTokenKey(userGuid);
            using (var context = new GapContext())
            {
                context.Entry(userToken).State = userToken.EntityState.ToEntityFrameworkState();
                context.SaveChanges();
                return userToken.TokenId;
            }
        }
        public bool Delete(Guid webUserTokenGuid)
        {
            using (var context = new GapContext())
            {
                bool flagReturn = false;
                var userToken = context.GAPWebAPIUserToken.Where(y => y.TokenId == webUserTokenGuid).FirstOrDefault();
                if (userToken == null) return flagReturn;

                context.GAPWebAPIUserToken.Remove(userToken);
                context.SaveChanges();
                flagReturn = true;
                return flagReturn;
            }
        }

        public bool ExpiredTokenKey(Guid? tokenId)
        {

            using (var context = new GapContext())
            {
                var token = context.GAPWebAPIUserToken.AsNoTracking().Where(x => x.TokenId == tokenId).FirstOrDefault();
                return token.TokenExpireDateTime < DateTime.Now;
            }
           
        }



        private GAPWebAPIUserToken CreateTokenKey(Guid userGuid)
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
