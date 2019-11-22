using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.DataContext;
using TesteEstapar.Models;
using TesteEstapar.Validators;

namespace TesteEstapar.Repositorios
{
    public class ManobristaRepositorio : ICrud<Manobrista>
    {
        private EstaparContext dbContext;
        private ManobristaValidator validator;
        public ManobristaRepositorio(EstaparContext context, ManobristaValidator manobristaValidator)
        {
            dbContext = context;
            validator = manobristaValidator;
        }

        public IEnumerable<Manobrista> Listar()
        {
            return dbContext.Manobristas;
        }
        public void Adicionar(Manobrista manobrista)
        {
            var result = validator.Validate(manobrista);
            if (!result.IsValid) throw new ArgumentException($"Validações falharam. {String.Join(",", result.Errors)}");
            dbContext.Manobristas.Add(manobrista);
            
            dbContext.SaveChanges();
            
        }

        public void Alterar(Manobrista model)
        {
            var result = validator.Validate(model);
            if (!result.IsValid) throw new ArgumentException($"Validações falharam. {String.Join(",", result.Errors)}");
            dbContext.Manobristas.Update(model);
            dbContext.SaveChanges();
        }

        public void Excluir(Manobrista model)
        {
            dbContext.Manobristas.Remove(model);
            dbContext.SaveChanges();
        }

        public Manobrista Obter(object id)
        {
            string cpf = id.ToString();
            return dbContext.Manobristas.Where(m => m.Cpf == cpf).FirstOrDefault();
        }
    }
}
