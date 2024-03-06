using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicas : Menu
{
    public override void Executar(MusicaDAL musicaDAL)
    {
        var context = new ScreenSoundContext();
        var musicaDALL = new MusicaDAL(context);
        var artistaDAL = new ArtistaDAL(context);

        //base.Executar(MusicaDAL);
        ExibirTituloDaOpcao("Musicas do Artista");
        Console.Write("Digite o nome do artista que deseja Mostrar as Musicas: ");
        string nomeDoArtista = Console.ReadLine()!;

        
        var verificaArtista = artistaDAL.Listar().FirstOrDefault(artista => artista.Nome.Equals(nomeDoArtista));
        var verificaMusicaArtista = musicaDAL.ListarMusica().FirstOrDefault(musica => musica.Nome.Contains(musica.Nome));
        

        if (verificaArtista is not null && verificaMusicaArtista is not null)
        {       
            Console.WriteLine("\nDiscografia:");
            verificaMusicaArtista.ExibirFichaTecnica();
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        } 
    }
}
