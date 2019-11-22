using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteEstapar.Models;
using TesteEstapar.Repositorios;

namespace TesteEstapar.Controllers
{
    public class VeiculoController : Controller
    {
        VeiculoRepositorio repositorio;
        public VeiculoController(VeiculoRepositorio veiculoRepositorio)
        {
            repositorio = veiculoRepositorio;
        }
        // GET: Veiculo
        public ActionResult Index()
        {
            var veiculos = repositorio.Listar();
            return View(veiculos);
        }

        // GET: Veiculo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veiculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var veiculo = new Veiculo(collection["Marca"], collection["Modelo"], collection["Placa"]);
                repositorio.Adicionar(veiculo);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View("Error",new { Erro = ex.Message});
            }
        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(string id)
        {
            var veiculo = repositorio.Obter(id);
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var veiculo = repositorio.Obter(id);
                string marca = collection["Marca"];
                string modelo = collection["Modelo"];
                veiculo.AlterarMarca(marca);
                veiculo.AlterarModelo(modelo);
                repositorio.Alterar(veiculo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new { Erro = ex.Message });
            }
        }

        // GET: Veiculo/Delete/5
        public ActionResult Delete(string id)
        {
            var veiculo = repositorio.Obter(id);
            return View(veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var veiculo = repositorio.Obter(id);
                repositorio.Excluir(veiculo);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new { Erro = ex.Message });
            }
        }
    }
}