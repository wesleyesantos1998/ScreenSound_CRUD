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

            var context = new ScreenSoundContext();
            var artistaDAL = new ArtistaDAL(context);
            var listaArtistas = artistaDAL.Listar();

            foreach (var artista in listaArtistas)
            {
                Console.WriteLine($"Artista: {artista.Nome}");
            }

            Console.WriteLine("Escolha um artista para estar atualizando o nome: ");
            string nomeArtista = Console.ReadLine()!;

            var AtualizarArtista = listaArtistas.FirstOrDefault(artista => artista.Nome == nomeArtista);
            if (AtualizarArtista != null)
            {
                Console.WriteLine("Artista encontrado com sucesso!\n");
                Console.WriteLine("Digite um novo nome para o artista: ");
                string nomeArtistaa = Console.ReadLine()!;

                Console.WriteLine("Digite um nova bio: ");
                string bioArtista= Console.ReadLine()!;


                artistaDAL.Remover(AtualizarArtista);


                var NovoArtista = new Artista (nomeArtistaa, bioArtista);

                artistaDAL.Atualizar(NovoArtista);
                Console.WriteLine("Registro Atualizado com Sucesso");

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
