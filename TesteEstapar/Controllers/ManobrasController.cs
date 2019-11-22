using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TesteEstapar.Models;
using TesteEstapar.Repositorios;

namespace TesteEstapar.Controllers
{
    public class ManobrasController : Controller
    {
        private ManobristasVeiculosRepositorio repositorio;
        private ManobristaRepositorio manobristaRepositorio;
        private VeiculoRepositorio veiculoRepositorio;
        public ManobrasController(ManobristasVeiculosRepositorio manobristasVeiculosRepositorio, ManobristaRepositorio _manobristaRepositorio, VeiculoRepositorio _veiculoRepositorio)
        {
            repositorio = manobristasVeiculosRepositorio;
            manobristaRepositorio = _manobristaRepositorio;
            veiculoRepositorio = _veiculoRepositorio;
        }
        // GET: Manobras
        public ActionResult Index()
        {
            var responsavel = repositorio.Listar();
            return View(responsavel);
        }

                

        // GET: Manobras/Create
        public ActionResult Create()
        {
            MontarCombos();

            return View();
        }

        // POST: Manobras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                
                repositorio.Adicionar(MontarManobra(collection));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        // GET: Manobras/Edit/5
        public ActionResult Edit(int id)
        {
            var manobra = repositorio.Obter(id);

            MontarCombos(manobra);


            return View(manobra);
        }

        // POST: Manobras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var manobra = repositorio.Obter(id);

                repositorio.Alterar(MontarManobra(collection));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        // GET: Manobras/Delete/5
        public ActionResult Delete(int id)
        {
            var manobra = repositorio.Obter(id);
            return View(manobra);
        }

        // POST: Manobras/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var manobra = repositorio.Obter(id);
                repositorio.Excluir(manobra);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        private ManobristaVeiculo MontarManobra(IFormCollection collection)
        {
            var idManobrista = collection["Manobrista"];
            var idVeiculo = collection["Veiculo"];

            var manobrista = manobristaRepositorio.Obter(idManobrista);
            var veiculo = veiculoRepositorio.Obter(idVeiculo);
            var manobra = new ManobristaVeiculo(idManobrista, idVeiculo, manobrista, veiculo);
            return manobra;
        }

        private void MontarCombos(ManobristaVeiculo manobra = null)
        {
            ViewBag.Manobristas = manobristaRepositorio.Listar().Select(m => new SelectListItem($"{m.Cpf} - {m.Nome}", m.Cpf, m.Cpf == manobra?.CpfManobrista));
            ViewBag.Veiculos = veiculoRepositorio.Listar().Select(v => new SelectListItem($"{v.Placa} - {v.Marca} - {v.Modelo}", v.Placa, v.Placa == manobra?.PlacaVeiculo));
        }
    }
}