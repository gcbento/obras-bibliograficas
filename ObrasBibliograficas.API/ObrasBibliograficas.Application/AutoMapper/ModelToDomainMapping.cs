using AutoMapper;
using ObrasBibliograficas.Application.Models.Request;
using ObrasBibliograficas.Domain.Entitties;

namespace ObrasBibliograficas.Application.AutoMapper
{
    public class ModelToDomainMapping : Profile
    {
        public ModelToDomainMapping()
        {
            CreateMap<BaseModelRequest, BaseEntity>();
            CreateMap<PessoaRequest, Pessoa>();
        }
    }
}
