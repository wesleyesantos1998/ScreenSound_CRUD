using ScreenSound.Modelos;
using ScreenSound.Banco;
using System;
using System.Collections.Generic;
using Microsoft.Identity.Client;

namespace ScreenSound.Menus
{
    internal class AtualizarArtista:Menu
    {
        public override void Executar(Dictionary<string, Artista> artistasRegistrados)
        {
            base.Executar(artistasRegistrados);
            ExibirTituloDaOpcao("Exibindo todos os artistas registrados na nossa aplicação");

            var artistaDAL = new ArtistaDAL();
            var listaArtistas = artistaDAL.Listar();

            foreach (var artista in listaArtistas)
            {
                Console.WriteLine($"Artista: {artista.Nome}");
            }

            Console.WriteLine("Escolha um artista para estar atualizando o nome: ");
            string nomeArtista = Console.ReadLine()!;

            var AtualizarArtista = listaArtistas.FirstOrDefault(artista => artista.Nome == nomeArtista);
            if (nomeArtista != null)
            {
                Console.WriteLine("Artista encontrado com sucesso!\n");
                Console.WriteLine("Digite um novo nome para o artista: ");
                string NovoNomeArtista = Console.ReadLine()!;
                

                artistaDAL.Atualizar(NovoNomeArtista);   

            }
            else
            {
                Console.WriteLine("Artista Não Encontrado");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
