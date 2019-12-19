using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class CountriesController : ApiController
    {
        public IEnumerable<tbl_Countries> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_Countries.ToList();
            }

        }

        public tbl_Countries POST([FromBody]tbl_Countries countries)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_Countries.Add(countries);
                entity.SaveChanges();
                return countries;
            }
        }
    }
}
