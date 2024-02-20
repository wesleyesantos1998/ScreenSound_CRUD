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
        //Abrindo conexão com banco de dados e executando comando SQL armazenando em lista para mostrar aqui no C#.
        //SQLComand - representa a instrução SQL que será executada no banco de dados;
        //SQLDataReader - fornece um modo de ler as linhas do banco de dados.


        //SELECT
        public IEnumerable<Artista> Listar()
        {
            var lista = new List<Artista>();
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "SELECT * FROM ARTISTAS";
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string nomeArtista = Convert.ToString(dataReader["Nome"]);
                string bioArtista = Convert.ToString(dataReader["Bio"]);
                int idArtista = Convert.ToInt32(dataReader["Id"]);
                Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };

                lista.Add(artista);
            }

            return lista;
        }
        
        //INSERT 
        public void Adicionar(Artista artista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "INSERT INTO ARTISTAS (NOME, FOTOPERFIL, BIO) VALUES (@NOME, @PERFILPADRAO, @BIO)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@NOME", artista.Nome);
            command.Parameters.AddWithValue("@PERFILPADRAO", artista.FotoPerfil);
            command.Parameters.AddWithValue("@BIO", artista.Bio);

            int retorno = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno}");
        }

        //DELETE
        public void Remover(Artista artista)
        {
            using (var connection = new Connection().ObterConexao())
            {
                connection.Open();

                string sql = "DELETE FROM ARTISTAS WHERE Id = @id"; 
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", artista.Id);
                int retorno = command.ExecuteNonQuery();
                Console.WriteLine($"Linhas afetadas: {retorno}");
            }
        }

        
        public void Atualizar(string novoNomeArtista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "UPDATE ARTISTAS SET NOME = @NOVO_NOME WHERE NOME = @NOME_ANTIGO";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@NOVO_NOME", novoNomeArtista);
            command.Parameters.AddWithValue("@NOME_ANTIGO", novoNomeArtista); // No seu caso, o nome antigo é o mesmo que o novo nome

            int retorno = command.ExecuteNonQuery();
            Console.WriteLine($" Linhas Afetadas: {retorno}");
        }

    }
}
