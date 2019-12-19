using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class ClaimHistoryController : ApiController
    {
        public IEnumerable<tbl_ClaimHistory> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_ClaimHistory.ToList();
            }

        }

        public tbl_ClaimHistory POST([FromBody]tbl_ClaimHistory claimHistory)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_ClaimHistory.Add(claimHistory);
                entity.SaveChanges();
                return claimHistory;
            }
        }
    }
}
