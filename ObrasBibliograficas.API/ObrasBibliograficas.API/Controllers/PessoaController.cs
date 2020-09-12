using Microsoft.AspNetCore.Mvc;
using ObrasBibliograficas.Application.Interfaces;
using ObrasBibliograficas.Application.Models.Request;

namespace ObrasBibliograficas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : BaseController
    {
        private readonly IPessoaApplication _pessoaApplication;

        public PessoaController(IPessoaApplication pessoaApplication)
        {
            _pessoaApplication = pessoaApplication;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int pageNumber = 0, int pageSize = 0)
        {
            //if (pageNumber > 0 && pageSize > 0)
            //{
            var games = _pessoaApplication.GetAll(pageNumber, pageSize);
            return GetResponse(games);
            //}
            //else
            //{
            //    //var game = _pessoaApplication.GetBy(filter);
            //    //return GetResponse(game);
            //}
        }

        [HttpPost]
        public ActionResult Post([FromBody] PessoaRequest request)
        {
            var result = _pessoaApplication.Add(request);
            return GetResponse(result);
        }

        [HttpPut]
        public ActionResult Put([FromBody] PessoaRequest request)
        {
            var result = _pessoaApplication.Update(request);
            return GetResponse(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            var result = _pessoaApplication.Delete(id);
            return GetResponse(result);
        }
    }
}
