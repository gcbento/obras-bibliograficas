using FluentValidation;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Domain.Validations.Interfaces;

namespace ObrasBibliograficas.Domain.Validations
{
    public class PessoaValidation : BaseValidation<Pessoa, IPessoaRepository>, IPessoaValidation
    {
        public PessoaValidation(IPessoaRepository repository) : base(repository)
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(g => g.Nome)
                  .NotEmpty().WithMessage("Nome é obrigatório.");
        }
    }
}
