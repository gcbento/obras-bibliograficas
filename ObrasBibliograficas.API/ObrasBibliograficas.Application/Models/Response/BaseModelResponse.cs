using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Application.Models.Response
{
    public class BaseModelResponse
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
