using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Application.Models.Response
{
    public class ResponseModel<T>
    {
        public bool Success
        {
            get
            {
                return Data != null;
            }
        }
        public T Data { get; set; }
        public string[] Messages { get; set; }

        public static ResponseModel<T> GetResponse(T result)
        {
            var response = new ResponseModel<T>();
            response.Data = result;
            return response;
        }

        public static ResponseModel<T> GetReponseErrors(IList<ValidationFailure> errors)
        {
            List<string> messageErrors = null;
            if (errors != null && errors.Count > 0)
            {
                messageErrors = new List<string>();
                foreach (var error in errors)
                {
                    messageErrors.Add(error.ErrorMessage);
                }

                var response = new ResponseModel<T>();
                response.Messages = messageErrors.ToArray();

                return response;
            }

            return null;
        }

        public static ResponseModel<T> GetReponseErrors(string mensagem)
        {
            var messageErrors = new List<string> { mensagem };

            var response = new ResponseModel<T>();
            response.Messages = messageErrors.ToArray();

            return response;
        }
    }
}
