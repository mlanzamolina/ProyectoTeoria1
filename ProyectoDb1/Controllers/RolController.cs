using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoDb1.Controllers
{
    public class RolController : ApiController
    {
        [HttpGet]
        [Route("api/Rol")]
        public HttpResponseMessage Get()
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var roles = db.roles.ToList();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, roles);
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/Rol/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var role = db.roles.Find(id);
                    HttpResponseMessage response;
                    if (role != null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, role);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}