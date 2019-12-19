using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class StatusController : ApiController
    {
        public IEnumerable<tbl_Status> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_Status.ToList();
            }

        }

        public tbl_Status POST([FromBody]tbl_Status status)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_Status.Add(status);
                entity.SaveChanges();
                return status;
            }
        }
    }
}
