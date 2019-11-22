using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.Models;

namespace TesteEstapar.Repositorios
{
    interface ICrud<T> where T : IModel
    {
        IEnumerable<T> Listar();
        void Adicionar(T model);
        void Alterar(T model);
        void Excluir(T model);
        T Obter(object id);
    }
}
