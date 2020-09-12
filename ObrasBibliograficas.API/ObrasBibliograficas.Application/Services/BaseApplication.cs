using AutoMapper;
using ObrasBibliograficas.Application.Interfaces;
using ObrasBibliograficas.Application.Models.Request;
using ObrasBibliograficas.Application.Models.Response;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Filters;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Domain.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObrasBibliograficas.Application.Services
{
    public class BaseApplication<TEntity, TRequest, TResponse, TFilter> : IBaseApplication<TRequest, TResponse,TFilter>
        where TEntity : BaseEntity
        where TRequest : BaseModelRequest
        where TResponse : BaseModelResponse
        where TFilter : BaseFilter
    {
        public readonly IBaseRepository<TEntity, TFilter> Repository;
        public readonly IMapper Mapper;
        public readonly IBaseValidation<TEntity> Validate;

        public BaseApplication(IBaseRepository<TEntity, TFilter> repository, IBaseValidation<TEntity> validate, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
            Validate = validate;
        }

        public ResponseModel<bool?> Add(TRequest request)
        {
            try
            {
                var entity = Mapper.Map<TEntity>(request);
                var entityValidate = Validate.Validate(entity);

                if (entityValidate.IsValid)
                {
                    var objResponse = Mapper.Map<TResponse>(Repository.Add(entity));
                    var added = objResponse.Id > 0;
                    return ResponseModel<bool?>.GetResponse(added);
                }
                else
                {
                    return ResponseModel<bool?>.GetReponseErrors(entityValidate.Errors);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseModel<bool?> Delete(int id)
        {
            try
            {
                var entity = Repository.GetAll().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    var delete = Repository.Delete(id);
                    return ResponseModel<bool?>.GetResponse(delete);
                }
                else
                {
                    return ResponseModel<bool?>.GetReponseErrors("Id não encontrado para exclusão");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual ResponseModel<TResponse> GetBy(TFilter filter)
        {
            try
            {
                TResponse response = null;

                var allEntities = Repository.GetAll(filter);

                if (allEntities != null && allEntities.Count() > 0)
                {
                    var entity = allEntities.FirstOrDefault();
                    response = Mapper.Map<TResponse>(entity);
                }

                var result = ResponseModel<TResponse>.GetResponse(response);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseModel<PagedResponse<TResponse>> GetAll(TFilter filter, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var pagedResponse = new PagedResponse<TResponse>();
                var listResponse = new List<TResponse>();

                var allEntities = Repository.GetAll(filter, pageNumber, pageSize, true);

                if (allEntities != null && allEntities.Count() > 0)
                {
                    pagedResponse.Total = allEntities.Count();
                    pagedResponse.CurrentPage = pageNumber;

                    var listEntity = allEntities.ToList();

                    listResponse = Mapper.Map<List<TResponse>>(listEntity);

                    pagedResponse.TotalPage = listResponse.Count;
                    pagedResponse.ListData = listResponse;
                }

                var resultList = ResponseModel<PagedResponse<TResponse>>.GetResponse(pagedResponse);

                return resultList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel<bool?> Update(TRequest request)
        {
            try
            {
                var entity = Mapper.Map<TEntity>(request);
                var entityValidate = Validate.Validate(entity);

                if (entityValidate.IsValid)
                {
                    var updated = Repository.Update(entity);
                    return ResponseModel<bool?>.GetResponse(updated);
                }
                else
                {
                    return ResponseModel<bool?>.GetReponseErrors(entityValidate.Errors);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
