using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class ZipCodesController : ApiController
    {
        public IEnumerable<tbl_ZipCodes> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_ZipCodes.ToList();
            }

        }

        public tbl_ZipCodes POST([FromBody]tbl_ZipCodes zipCodes)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_ZipCodes.Add(zipCodes);
                entity.SaveChanges();
                return zipCodes;
            }
        }
    }
}
