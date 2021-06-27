using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoDb1.Controllers
{
    public class SolicitudProyectoController : ApiController
    {
        [HttpGet]
        [Route("api/SolicitudProyecto")]
        public HttpResponseMessage Get()
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var projectRequests = db.solicitudesproyecto.ToList();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projectRequests);
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/SolicitudProyecto/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var projectRequest = db.usuarios.Find(id);
                    HttpResponseMessage response;
                    if (projectRequest != null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, projectRequest);
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

        [HttpPost]
        [Route("api/SolicitudProyecto")]
        public HttpResponseMessage Post([FromBody] solicitudesproyecto projectRequest)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    db.solicitudesproyecto.Add(projectRequest);
                    db.SaveChanges();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, projectRequest);
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        [Route("api/SolicitudProyecto/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] solicitudesproyecto projectRequest)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var result = db.solicitudesproyecto.SingleOrDefault(s => s.IDSolicitudProyecto == id);
                    if (result != null)
                    {
                        db.Entry(result).CurrentValues.SetValues(projectRequest);
                        db.SaveChanges();
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                        return response;
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}