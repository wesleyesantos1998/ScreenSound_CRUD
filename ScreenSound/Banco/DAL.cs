using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal abstract class DAL<T> where T : class
    {
        protected readonly ScreenSoundContext context;

        protected DAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        //SELECT
        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        //INSERT
        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }

        //DELETE
        public void Remover(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        //UPDATE
        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }
    }
}
