using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(Dictionary<string, Artista> musicasRegistradas)
    {
        base.Executar(musicasRegistradas);
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        var ArtistaDAL = new ArtistaDAL();
        var ListaArtista = ArtistaDAL.Listar();

        foreach (var artist in ListaArtista)
        {
            Console.WriteLine($"Artista: {artist}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
