using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class ParkingCompaniesController : ApiController
    {
        public IEnumerable<tbl_ParkingCompanies> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_ParkingCompanies.ToList();
            }

        }


        public tbl_ParkingCompanies POST([FromBody]tbl_ParkingCompanies parkingCompanies)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_ParkingCompanies.Add(parkingCompanies);
                entity.SaveChanges();
                return parkingCompanies;
            }
        }
    }
}
