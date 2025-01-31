using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Newpedidos.Application.Command.InsertProduct;

namespace Newpedidos.Application.Validator
{
    public class InsertProductValidator : AbstractValidator<InsertProductCommand>
    {
        public InsertProductValidator()
        {
            RuleFor(p => p.Quantity)
                .NotEmpty()
                .WithMessage("A quantidade deve ser preenchida");

            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("O Preço deve ser preenchido");

        }
    }
}
