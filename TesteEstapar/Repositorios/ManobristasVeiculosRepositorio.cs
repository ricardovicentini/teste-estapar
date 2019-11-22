using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.DataContext;
using TesteEstapar.Models;

namespace TesteEstapar.Repositorios
{
    public class ManobristasVeiculosRepositorio : ICrud<ManobristaVeiculo>
    {
        EstaparContext dbContext;
        public ManobristasVeiculosRepositorio(EstaparContext context)
        {
            dbContext = context;
        }
        public void Adicionar(ManobristaVeiculo model)
        {
            dbContext.ManobristasVeiculos.Add(model);
            dbContext.SaveChanges();
            

        }

        public void Alterar(ManobristaVeiculo model)
        {
            dbContext.ManobristasVeiculos.Update(model);
            dbContext.SaveChanges();

        }

        public void Excluir(ManobristaVeiculo model)
        {
            dbContext.ManobristasVeiculos.Remove(model);
            dbContext.SaveChanges();
        }

        public IEnumerable<ManobristaVeiculo> Listar()
        {
            return dbContext.ManobristasVeiculos
                .Join(dbContext.Manobristas,
                    mv => mv.CpfManobrista,
                    ma => ma.Cpf, (mv, ma) => new { mv, ma })
                .Join(dbContext.Veiculos,
                    mv1 => mv1.mv.PlacaVeiculo,
                    ma1 => ma1.Placa, (mv1, ma1) => new { mv1, ma1 })
                .Select(x => new ManobristaVeiculo(
                    x.mv1.mv.IdManobra,
                    x.mv1.mv.DataManobra,
                    x.mv1.mv.CpfManobrista,
                    x.mv1.mv.PlacaVeiculo,
                    new Manobrista(x.mv1.ma.Nome, x.mv1.ma.Cpf, x.mv1.ma.DataNascimento),
                    new Veiculo(x.ma1.Marca, x.ma1.Modelo, x.ma1.Placa)));
                    

        }

        public ManobristaVeiculo Obter(object id)
        {
            var _id = (int)id;
            
            
            return dbContext.ManobristasVeiculos.Where(mv =>  mv.IdManobra == _id).FirstOrDefault();
        }
    }
}
