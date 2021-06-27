using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace ProyectoDb1.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("api/Usuario")]
        public HttpResponseMessage Get()
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var users = db.usuarios.ToList();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, users);
                    return response;
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/Usuario/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var user = db.usuarios.Find(id);
                    HttpResponseMessage response;
                    if (user != null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, user);
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
        [Route("api/Usuario")]
        public HttpResponseMessage Post([FromBody] usuarios user)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    db.usuarios.Add(user);
                    db.SaveChanges();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
                    return response;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        [Route("api/Usuario/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] usuarios user)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var result = db.usuarios.SingleOrDefault(u => u.IDUsuario == id);
                    if (result != null)
                    {
                        db.Entry(result).CurrentValues.SetValues(user);
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

        [HttpDelete]
        [Route("api/Usuario/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (bfzkzkyq0abmhdbsc2ruEntities db = new bfzkzkyq0abmhdbsc2ruEntities())
                {
                    var result = db.usuarios.SingleOrDefault(u => u.IDUsuario == id);
                    if (result != null)
                    {
                        db.usuarios.Remove(result);
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