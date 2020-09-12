using ObrasBibliograficas.Application.Models.Request;
using ObrasBibliograficas.Application.Models.Response;
using ObrasBibliograficas.Domain.Filters;

namespace ObrasBibliograficas.Application.Interfaces
{
    public interface IPessoaApplication : IBaseApplication<PessoaRequest, PessoaResponse, PessoaFilter>
    {
    }
}
