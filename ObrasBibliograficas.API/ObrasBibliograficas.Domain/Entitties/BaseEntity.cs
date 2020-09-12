using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Domain.Entitties
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
