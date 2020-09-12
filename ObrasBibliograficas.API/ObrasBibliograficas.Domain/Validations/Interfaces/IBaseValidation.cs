using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Domain.Validations.Interfaces
{
    public interface IBaseValidation<T> : IValidator<T>
    {
        void ValidatesBase();
    }
}
