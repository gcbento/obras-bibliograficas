using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Infra.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ObrasBibliograficasContext context) : base(context)
        {
        }
    }
}
