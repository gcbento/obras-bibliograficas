using ObrasBibliograficas.Application.Models.Request;
using ObrasBibliograficas.Application.Models.Response;
using ObrasBibliograficas.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Application.Interfaces
{
    public interface IBaseApplication<TRequest, TResponse, TFilter>
        where TRequest : BaseModelRequest
        where TResponse : BaseModelResponse
        where TFilter : BaseFilter
    {
        ResponseModel<bool?> Add(TRequest model);

        ResponseModel<bool?> Update(TRequest model);

        ResponseModel<bool?> Delete(int id);

        ResponseModel<TResponse> GetBy(TFilter filter);

        ResponseModel<PagedResponse<TResponse>> GetAll(TFilter filter, int pageNumber = 1, int pageSize = 10);
    }
}
