using AutoMapper;
using ObrasBibliograficas.Application.Interfaces;
using ObrasBibliograficas.Application.Models.Request;
using ObrasBibliograficas.Application.Models.Response;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Domain.Validations.Interfaces;
using System;

namespace ObrasBibliograficas.Application.Services
{
    public class PessoaApplication : BaseApplication<Pessoa, PessoaRequest, PessoaResponse>, IPessoaApplication
    {
        public PessoaApplication(IPessoaRepository repository,
                                 IPessoaValidation validate,
                                 IMapper mapper) : base(repository, validate, mapper)
        { }
    }
}
