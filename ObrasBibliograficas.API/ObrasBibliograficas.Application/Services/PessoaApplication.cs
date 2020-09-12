using AutoMapper;
using ObrasBibliograficas.Application.Interfaces;
using ObrasBibliograficas.Application.Models.Request;
using ObrasBibliograficas.Application.Models.Response;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Filters;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Domain.Validations.Interfaces;
using System;

namespace ObrasBibliograficas.Application.Services
{
    public class PessoaApplication : BaseApplication<Pessoa, PessoaRequest, PessoaResponse, PessoaFilter>, IPessoaApplication
    {
        public PessoaApplication(IPessoaRepository repository,
                                 IPessoaValidation validate,
                                 IMapper mapper) : base(repository, validate, mapper)
        { }

        public override ResponseModel<PessoaResponse> GetBy(PessoaFilter filter)
        {
            if (filter.Id > 0 || !string.IsNullOrEmpty(filter.Nome))
                return base.GetBy(filter);
            else
                return ResponseModel<PessoaResponse>.GetResponse(null);
        }
    }
}
