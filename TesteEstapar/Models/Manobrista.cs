using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.Models
{
    public class Manobrista : IModel
    {
        public Manobrista(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
        
        [DataType(DataType.Date)]
        [Display(Name ="Data de nascimento")]
        public DateTime DataNascimento { get; protected set; }

        public ManobristaVeiculo ManobristaVeiculo { get; protected set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

    }
}
