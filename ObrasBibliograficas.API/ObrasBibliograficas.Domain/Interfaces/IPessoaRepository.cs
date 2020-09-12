using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Filters;

namespace ObrasBibliograficas.Domain.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa, PessoaFilter>
    {
    }
}
