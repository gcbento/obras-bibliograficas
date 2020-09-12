using Microsoft.AspNetCore.Mvc;
using ObrasBibliograficas.API.Attributes;
using ObrasBibliograficas.Application.Interfaces;
using ObrasBibliograficas.Application.Models.Request;
using ObrasBibliograficas.Domain.Filters;

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
        public ActionResult Get([FromQuery] PessoaFilter filter, int pageNumber = 0, int pageSize = 0)
        {
            if (pageNumber > 0 && pageSize > 0)
            {
                var pessoas = _pessoaApplication.GetAll(filter, pageNumber, pageSize);
                return GetResponse(pessoas);
            }
            else
            {
                var pessoa = _pessoaApplication.GetBy(filter);
                return GetResponse(pessoa);
            }
        }

        [HttpPost]
        [ValidateModel]
        public ActionResult Post([FromBody] PessoaRequest request)
        {
            var result = _pessoaApplication.Add(request);
            return GetResponse(result);
        }

        [HttpPut]
        [ValidateModel]
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
