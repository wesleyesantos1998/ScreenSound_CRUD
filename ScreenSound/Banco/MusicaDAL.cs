using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
    internal class MusicaDAL
    {
        private readonly ScreenSoundContext context;

        public MusicaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        //SELECT 
        public IEnumerable<Musica> ListarMusica()
        {
            return context.Musicas.ToList();
        }

        //INSERT
        public void Adicionar(Musica musica)
        {
            context.Musicas.Add(musica);
            context.SaveChanges();
        }

        //DELETE

        public void Deletar(Musica musica)
        {
            context.Musicas.Remove(musica); 
            context.SaveChanges();
        }

        //ATUALIZAR 
        
        public void Atualizar(Musica musica) 
        {
            context.Update(musica);
            context.SaveChanges();
        }

    }
}
