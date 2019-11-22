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
    public class ManobristaController : Controller
    {
        private ManobristaRepositorio repositorio;
        public ManobristaController(ManobristaRepositorio manobristaRepositorio)
        {
            repositorio = manobristaRepositorio;
            

            
        }

        

        // GET: Manobrista
        public ActionResult Index()
        {
            var manobristas = repositorio.Listar();
            return View(manobristas);
        }

        

        // GET: Manobrista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manobrista/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                DateTime dtNascimento = ConverterData(collection["DataNascimento"]);
                repositorio.Adicionar(new Manobrista(collection["Nome"], collection["Cpf"], dtNascimento));
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        // GET: Manobrista/Edit/5
        public ActionResult Edit(string id)
        {
            var manobrista = repositorio.Obter(id);
            return View(manobrista);
        }

        // POST: Manobrista/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var manobrista = repositorio.Obter(id);
                DateTime dtNascimento = ConverterData(collection["DataNascimento"]);
                string nome = collection["Nome"];
                manobrista.AlterarNome(nome);
                manobrista.AlterarNascimento(dtNascimento);
                repositorio.Alterar(manobrista);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        // GET: Manobrista/Delete/5
        public ActionResult Delete(string id)
        {

            var manobrista = repositorio.Obter(id);
            return View(manobrista);
        }

        // POST: Manobrista/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var manobrista = repositorio.Obter(id);
                repositorio.Excluir(manobrista);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error",new ErrorViewModel{RequestId= ex.Message });
            }
        }

        private DateTime ConverterData(string dataNascimento)
        {
            DateTime dtNascimento = DateTime.TryParse(dataNascimento, out dtNascimento) ? dtNascimento : DateTime.MinValue;
            if (dtNascimento == DateTime.MinValue)
                throw new ArgumentException("Data de nascimento inválida");
            return dtNascimento;
        }
    }
}