using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.DataContext;
using TesteEstapar.Models;
using TesteEstapar.Validators;

namespace TesteEstapar.Repositorios
{
    public class VeiculoRepositorio : ICrud<Veiculo>
    {
        private EstaparContext dbContext;
        private VeiculoValidator validator;
        public VeiculoRepositorio(EstaparContext estaparContext,VeiculoValidator veiculoValidator)
        {
            dbContext = estaparContext;
            validator = veiculoValidator;
        }
        public void Adicionar(Veiculo model)
        {
            var result = validator.Validate(model);
            if (!result.IsValid) throw new ArgumentException($"Validações falharam. {String.Join(",", result.Errors)}");
            dbContext.Veiculos.Add(model);
            dbContext.SaveChanges();
            
        }

        public void Alterar(Veiculo model)
        {
            var result = validator.Validate(model);
            if (!result.IsValid) throw new ArgumentException($"Validações falharam. {String.Join(",", result.Errors)}");
            dbContext.Veiculos.Update(model);
            dbContext.SaveChanges();
        }

        public void Excluir(Veiculo model)
        {
            dbContext.Veiculos.Remove(model);
            dbContext.SaveChanges();
        }

        public IEnumerable<Veiculo> Listar()
        {
            return dbContext.Veiculos;
        }

        public Veiculo Obter(object id)
        {
            string placa = id.ToString();
            return dbContext.Veiculos.Where(v=> v.Placa == placa).FirstOrDefault();
        }
    }
}
