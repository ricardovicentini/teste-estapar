using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.Models
{
    public class ManobristaVeiculo : IModel
    {
        public ManobristaVeiculo()
        {

        }
        public ManobristaVeiculo(string cpfManobrista, string placaVeiculo, Manobrista manobrista, Veiculo veiculo)
        {
            CpfManobrista = cpfManobrista;
            PlacaVeiculo = placaVeiculo;
            Manobrista = manobrista;
            Veiculo = veiculo;
            DataManobra = DateTime.Now;
        }

        public ManobristaVeiculo(int idManobra, DateTime dataManobra, string cpfManobrista, string placaVeiculo, Manobrista manobrista, Veiculo veiculo) 
            : this( cpfManobrista,placaVeiculo,manobrista,veiculo)
        {
            IdManobra = idManobra;
            DataManobra = dataManobra;
        }

        public int IdManobra { get; protected set; }
        public string CpfManobrista { get; set; }
        public string PlacaVeiculo { get; set; }
        public Manobrista Manobrista { get;  set; }
        public Veiculo Veiculo { get;  set; }
        public DateTime DataManobra { get; protected set; }

        public void AlterarVeiculo(String placa)
        {
            PlacaVeiculo = placa;
        }

        public void AlterarManobrista(string cpf)
        {
            CpfManobrista = cpf;
        }
    }
}
