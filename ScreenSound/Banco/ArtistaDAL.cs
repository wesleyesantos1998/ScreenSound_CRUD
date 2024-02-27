using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        private readonly ScreenSoundContext context;

        public ArtistaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }


        //Abrindo conexão com banco de dados e executando comando SQL armazenando em lista para mostrar aqui no C#.
        //SQLComand - representa a instrução SQL que será executada no banco de dados;
        //SQLDataReader - fornece um modo de ler as linhas do banco de dados.


        //SELECT
        public IEnumerable<Artista> Listar()
        {            
            return context.Artistas.ToList();
        }
  
        
        //INSERT 
        public void Adicionar(Artista artista)
        {
            context.Artistas.Add(artista);
            context.SaveChanges();
        }

        //DELETE
        public void Remover(Artista artista)
        {
           context.Artistas.Remove(artista);
            context.SaveChanges();
        }

        //ATUALIZAR
        public void Atualizar(Artista artista)
        {
            context.Artistas.Update(artista);
            context.SaveChanges();
        }

    }
} 
