using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Newpedidos.Application.Command.InsertOrder;

namespace Newpedidos.Application.Validator
{
    public class InsertOrderValidator : AbstractValidator<InsertOrderCommand>
    {
        public InsertOrderValidator()
        {
            RuleFor(o => o.ClientName)
                .NotEmpty()
                .WithMessage("O Nome do Cliente não pode estar vázio")
            .MinimumLength(3)
            .WithMessage("O Número de caracteres é insuficiente")
            .MaximumLength(35)
            .WithMessage("O Número de caracteres máximo são 35");

            RuleFor(o => o.ClientDoc)
                .NotEmpty()
                .WithMessage("O Nome do Cliente não pode estar vázio")
            .MinimumLength(3)
            .WithMessage("O Número de caracteres é insuficiente")
            .MaximumLength(20)
            .WithMessage("O Número de caracteres máximo são 35");

        }
    }
}
