using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoDb1.Controllers
{
    public class ProyectoDesarrolloController : ApiController
    {
        [HttpGet]
        [Route("api/ProyectoDesarrollo")]
        public HttpResponseMessage Get()
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var projects = db.p_e_d.ToList();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projects);
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/ProyectoDesarrollo/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var project = db.p_e_d.Find(id);
                    HttpResponseMessage response;
                    if (project != null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, project);
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