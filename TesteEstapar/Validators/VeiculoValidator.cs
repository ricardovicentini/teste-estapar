using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.Models;

namespace TesteEstapar.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(veiculo => veiculo.Marca)
                .NotNull().WithMessage("Marca é obrigatório")
                .MaximumLength(10)
                .MinimumLength(2).WithMessage("Marca deve ter no minímo 2 e no máximo 10 caracteres");

            RuleFor(veiculo => veiculo.Modelo)
                .NotNull()
                .WithMessage("Modelo é obrigatório")
                .MaximumLength(10)
                .MinimumLength(1).WithMessage("Modelo deve ter no minímo 1 e no máximo 10 caracteres");

            RuleFor(veiculo=> veiculo.Placa)
                .NotNull()
                .WithMessage("Placa é obrigatório")
                .MaximumLength(8)
                .MinimumLength(7).WithMessage("Placa deve ter no minímo 7 e no máximo 8 caracteres");
        }
    }
}
