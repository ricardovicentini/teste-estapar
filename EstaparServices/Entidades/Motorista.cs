using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstaparServices.Entidades
{
    public class Motorista : AbstractValidator<Motorista>
    {
        public Motorista(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
    }
}
