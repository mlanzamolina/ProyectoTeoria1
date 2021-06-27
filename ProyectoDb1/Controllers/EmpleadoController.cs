using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoDb1.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/Empleado")]
        public HttpResponseMessage Get()
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var employees = db.empleados.ToList();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/Empleado/{usernameId}")]
        public HttpResponseMessage Get(int usernameId)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var employee = db.empleados.Find(usernameId);
                    HttpResponseMessage response;
                    if (employee != null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, employee);
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
        [Route("api/Empleado")]
        public HttpResponseMessage Post([FromBody] empleados employee)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    db.empleados.Add(employee);
                    db.SaveChanges();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employee);
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        [Route("api/Empleado/{usernameId}")]
        public HttpResponseMessage Put(int usernameId, [FromBody] empleados employee)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var result = db.empleados.SingleOrDefault(e => e.IDUsername == usernameId);
                    if (result != null)
                    {
                        db.Entry(result).CurrentValues.SetValues(employee);
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
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("api/Empleado/{usernameId}")]
        public HttpResponseMessage Delete(int usernameId)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var result = db.empleados.SingleOrDefault(e => e.IDUsername == usernameId);
                    if (result != null)
                    {
                        db.empleados.Remove(result);
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
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}