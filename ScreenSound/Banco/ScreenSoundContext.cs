using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
    internal class ScreenSoundContext: DbContext
    {
        //ADO.NET --> é um conjunto de classes que permitem acesso a dados nas aplicações .NET. Através dele é possível acessar dados de maneira consistente e ainda fazer a separação e a manipulação dos dados.
        //Realizando conexão com o bando de dados
        //SQLConnection - representa a conexão com o banco de dados;
        
        //SUBTITUIMOS DE ADO.NET PARA DBCONTEXT : que faz o mapeamento do banco de dados relacional com os objetos C# (FAMOSO ENTITY FRAMEWORK)

        
        //DB CONTEXT UTILIZADO ATUALMENTE: 

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas{ get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
   

}
