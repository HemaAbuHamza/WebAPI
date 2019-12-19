using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class LoginTypeController : ApiController
    {
        public IEnumerable<tbl_LoginType> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_LoginType.ToList();
            }

        }

        public tbl_LoginType POST([FromBody]tbl_LoginType loginType)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_LoginType.Add(loginType);
                entity.SaveChanges();
                return loginType;
            }
        }
    }
}
