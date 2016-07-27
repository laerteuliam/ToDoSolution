using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Contracts.Repositories;
using Domain.Entities;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ToDoController : ApiController
    {
        private IToDoRepository _repository;

        public ToDoController(IToDoRepository repository)
        {
            _repository = repository;
        }


        // GET: api/ToDo
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                IEnumerable<ToDoEntity> ret = _repository.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, ret);
            }
            catch (Exception exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível listar");
            }
            return response;
        }

        // GET: api/ToDo/5
        public ToDoEntity Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST: api/ToDo
        public async Task<HttpResponseMessage> Post(ToDoEntity entity)
        {
            HttpResponseMessage response;
            try
            {
                _repository.AddOrUpdate(entity);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível adicionar");
            }
            return response;
        }

        // DELETE: api/ToDo/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            try
            {
                _repository.Delete(id);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível deletar.");
            }
            return response;
        }
    }
}
