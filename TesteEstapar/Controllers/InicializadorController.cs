using System;

using Microsoft.AspNetCore.Mvc;
using TesteEstapar.Models;
using TesteEstapar.Repositorios;

namespace TesteEstapar.Controllers
{
    public class InicializadorController : Controller
    {
        private ManobristaRepositorio repositorio;
        private ManobristasVeiculosRepositorio manobristaVeiculoRepositorio;
        private VeiculoRepositorio veiculoRepositorio;

        public InicializadorController(ManobristasVeiculosRepositorio manobristaVeiculoRepositorio, ManobristaRepositorio manobristaRepositorio, VeiculoRepositorio veiculoRepositorio)
        {
            this.repositorio = manobristaRepositorio;
            this.manobristaVeiculoRepositorio = manobristaVeiculoRepositorio;
            this.veiculoRepositorio = veiculoRepositorio;
        }

        public IActionResult Index()
        {
            InicializarBD();

            return RedirectToAction("Index","Manobrista");
        }

        private void InicializarBD()
        {
            repositorio.Adicionar(new Manobrista("João", "11111111111", new DateTime(2000, 1, 1)));
            repositorio.Adicionar(new Manobrista("Maria", "11111111112", new DateTime(2001, 2, 1)));
            repositorio.Adicionar(new Manobrista("Paulo", "11111111113", new DateTime(2002, 3, 1)));
            veiculoRepositorio.Adicionar(new Veiculo("Peugeot", "408", "ABC-1234"));
            veiculoRepositorio.Adicionar(new Veiculo("Ford", "Ecosport", "ABC-1235"));
            //manobristaVeiculoRepositorio.Adicionar(new ManobristaVeiculo())
        }
    }
}