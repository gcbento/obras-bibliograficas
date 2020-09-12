using ObrasBibliograficas.Application.Models.Request;
using ObrasBibliograficas.Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Application.Interfaces
{
    public interface IBaseApplication<TRequest, TResponse>
        where TRequest : BaseModelRequest
        where TResponse : BaseModelResponse
    {
        ResponseModel<bool?> Add(TRequest model);

        ResponseModel<bool?> Update(TRequest model);

        ResponseModel<bool?> Delete(int id);

        //ResponseModel<TResponse> GetBy(TFilter id);

        ResponseModel<PagedResponse<TResponse>> GetAll(int pageNumber = 1, int pageSize = 10);
    }
}
