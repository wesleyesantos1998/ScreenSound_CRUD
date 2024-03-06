using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL:DAL<Artista>
    {
        public ArtistaDAL(ScreenSoundContext context) : base(context) { }


        //Abrindo conexão com banco de dados e executando comando SQL armazenando em lista para mostrar aqui no C#.
        //SQLComand - representa a instrução SQL que será executada no banco de dados;
        //SQLDataReader - fornece um modo de ler as linhas do banco de dados.

    }
} 
