using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClaimyWebServies.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        // Get all users data
        public IEnumerable<tbl_Users> Get()
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                return entity.tbl_Users.ToList();
            }

        }

        // Get a user data with spasific email address.
        [Route("api/Users/{emailAddress}")]
        public HttpResponseMessage Get(string emailAddress)
        {
            
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {       
                var entites = entity.tbl_Users.FirstOrDefault(e => e.fld_Email == emailAddress);

                if (entity != null)
                {
                    entity.Configuration.LazyLoadingEnabled = false;
                    return Request.CreateResponse(HttpStatusCode.OK, entites);
                }
                else
                {
                    entity.Configuration.LazyLoadingEnabled = false;
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound , "The email you Search for " + emailAddress.ToString() + " Not found");
                }
               
            }
            
        }

        // Create a new user.
        public tbl_Users POST([FromBody]tbl_Users users)
        {
            using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.tbl_Users.Add(users);
                entity.SaveChanges();
                return users;
            }
        }

        // Update the user data .
        [Route("api/Users/{emailAddress}")]
        public HttpResponseMessage Put(string emailAddress , [FromBody] tbl_Users user)
        {
            try
            {
                using (ClaimyWebServies_dbEntities2 entity = new ClaimyWebServies_dbEntities2())
                {
                    var entites = entity.tbl_Users.FirstOrDefault(e => e.fld_Email == emailAddress);


                    if (entites == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "User with email = " + emailAddress + " not found ");
                    }
                    else
                    {
                        //We just Keep the fld_UserID + fld_TypeID 
                        entites.fld_Title = user.fld_Title;
                        entites.fld_Fullname = user.fld_Fullname;
                        entites.fld_Email = user.fld_Email;
                        entites.fld_AuthKey = user.fld_AuthKey;
                        entites.fld_PasswordHash = user.fld_PasswordHash;
                        //entites.fld_SignupTime = user.fld_SignupTime;
                        //entites.fld_LastAction = user.fld_LastAction;
                        entites.fld_CustomerAddress = user.fld_CustomerAddress;
                        entites.fld_CustomerCountry = user.fld_CustomerCountry;
                        entites.Avtive = user.Avtive;

                        entity.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entites);

                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }


        /*
        public void Delete(string emailAddress)
        {
            using (ClaimyWebServies_dbEntite entity = new ClaimyWebServies_dbEntite())
            {
                entity.Configuration.ProxyCreationEnabled = false;
                entity.Configuration.LazyLoadingEnabled = false;
                entity.tbl_Users.Remove(entity.tbl_Users.FirstOrDefault(e => e.fld_Email == emailAddress));
                entity.SaveChanges();
            }
        }
        */


    }
}
