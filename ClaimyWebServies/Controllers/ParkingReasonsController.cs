using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class ParkingReasonsController : ApiController
    {
        public IEnumerable<tbl_ParkingReasons> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_ParkingReasons.ToList();
            }

        }


        public tbl_ParkingReasons POST([FromBody]tbl_ParkingReasons parkingReasons)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_ParkingReasons.Add(parkingReasons);
                entity.SaveChanges();
                return parkingReasons;
            }
        }
    }
}
