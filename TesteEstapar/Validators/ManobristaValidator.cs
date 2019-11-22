using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.Models;

namespace TesteEstapar.Validators
{
    public class ManobristaValidator : AbstractValidator<Manobrista>
    {
        public ManobristaValidator()
        {
            RuleFor(motorista => motorista.Nome)
                .NotNull()
                .WithMessage("Nome Obrigatório")
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("Nome deve ter entre 3 e 50 caracteres");


            RuleFor(motorista => motorista.Cpf)
                .NotNull()
                .WithMessage("Cpf Obrigatório")
                .Length(11)
                .WithMessage("Cpf inválido");


        }
    }
}
