using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Filters;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObrasBibliograficas.Infra.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa, PessoaFilter>, IPessoaRepository
    {
        public PessoaRepository(ObrasBibliograficasContext context) : base(context)
        {

        }

        public override IQueryable<Pessoa> GetAll(PessoaFilter filter, int pageNumber = 1, int pageSize = 10, bool contais = false)
        {
            var query = base.GetAll();

            if (filter.Id > 0)
                query = query.Where(x => x.Id == filter.Id);

            if (!string.IsNullOrEmpty(filter.Nome))
                query = query.Where(x => contais ? x.Nome.Contains(filter.Nome) : x.Nome.Equals(filter.Nome));

            if (contais)
                query = query.Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize);

            return query;
        }
    }
}
