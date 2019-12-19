using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class ClaimsController : ApiController
    {
        public IEnumerable<tbl_Claims> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_Claims.ToList();
            }

        }


        public tbl_Claims POST([FromBody]tbl_Claims claims)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_Claims.Add(claims);
                entity.SaveChanges();
                return claims;
            }
        }
    }
}
