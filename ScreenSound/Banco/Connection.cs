using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
    internal class Connection
    {
        //ADO.NET --> é um conjunto de classes que permitem acesso a dados nas aplicações .NET. Através dele é possível acessar dados de maneira consistente e ainda fazer a separação e a manipulação dos dados.
        //Realizando conexão com o bando de dados
        //SQLConnection - representa a conexão com o banco de dados;


        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }

        

       


    }
    
   

}
