using ScreenSound.Modelos;
using ScreenSound.Banco;
using System;
using System.Collections.Generic;

namespace ScreenSound.Menus
{
    internal class RemoverArtista : Menu
    {
        public override void Executar(ArtistaDAL artistaDAL)
        {
            var context = new ScreenSoundContext();
            //var artistaDAL = new ArtistaDAL(context);

            base.Executar(artistaDAL);
            ExibirTituloDaOpcao("Exibindo todos os artistas registrados na nossa aplicação");

           
            var listaArtistas = artistaDAL.Listar();

            foreach (var artista in listaArtistas)
            {
                Console.WriteLine($"Artista: {artista.Nome}");
            }

            Console.WriteLine("Escolha um artista pelo nome para removê-lo: ");
            string nomeArtista = Console.ReadLine()!;

            // Encontrar o artista na lista
            var artistaParaRemover = listaArtistas.FirstOrDefault(artista => artista.Nome == nomeArtista);
            if (artistaParaRemover != null)
            {

               artistaDAL.Remover(artistaParaRemover); // Chamar o método Remover com o objeto Artista
                Console.WriteLine("Artista removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Artista não encontrado na lista.");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
