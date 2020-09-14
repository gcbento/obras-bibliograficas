using FluentValidation;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Filters;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Domain.Validations.Interfaces;

namespace ObrasBibliograficas.Domain.Validations
{
    public class PessoaValidation : BaseValidation<Pessoa, PessoaFilter, IPessoaRepository>, IPessoaValidation
    {
        public PessoaValidation(IPessoaRepository repository) : base(repository)
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(g => g.Nome)
                  .NotEmpty().WithMessage("Nome é obrigatório.")
                  .Matches(@"/^[ a-zA-ZÀ-ÿ\u00f1\u00d1]*$/g").WithMessage("Não é permitido números");
                
        }
    }
}
