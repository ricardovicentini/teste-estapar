using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.Models
{
    public class Veiculo : IModel
    {
        public Veiculo(string marca, string modelo, string placa)
        {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
        }

        public string Marca { get; protected set; }
        public string Modelo { get; protected set; }
        public string Placa { get; protected set; }

        public ManobristaVeiculo ManobristaVeiculo { get; set; }
        public void AlterarMarca(string marca)
        {
            Marca = marca;
        }

        public void AlterarModelo(string modelo)
        {
            Modelo = modelo;
        }


    }
}
