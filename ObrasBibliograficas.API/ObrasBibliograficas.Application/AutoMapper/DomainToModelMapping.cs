using AutoMapper;
using ObrasBibliograficas.Application.Models.Response;
using ObrasBibliograficas.Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Application.AutoMapper
{
    public class DomainToModelMapping : Profile
    {
        public DomainToModelMapping()
        {
            CreateMap<BaseEntity, BaseModelResponse>();
            CreateMap<Pessoa, PessoaResponse>();
        }
    }
}
