using ScreenSound.Banco;
using ScreenSound.Menus;

internal class RemoverMusica : Menu
{
    public override void Executar(MusicaDAL musicaDAL)
    {

        var context = new ScreenSoundContext();
        var musicadall = new MusicaDAL(context);
        var artistaDAL = new ArtistaDAL(context);

        ExibirTituloDaOpcao("Musicas do Artista");
        Console.Write("Digite o nome do artista que deseja Mostrar as Musicas: ");
        string nomeDoArtista = Console.ReadLine()!;

        foreach (var music in musicaDAL.ListarMusica())
        {
            Console.WriteLine($"Musicas: {music.Nome}");
        }

        Console.WriteLine("Escolha uma Musica para estar removendo: ");
        string removeMusica = Console.ReadLine()!;

        var musicaRemover = musicaDAL.ListarMusica().FirstOrDefault(musica => musica.Nome.Equals(removeMusica));

        if (musicaRemover != null) 
        {
            musicaDAL.Deletar(musicaRemover);
            Console.WriteLine("Removido com Sucesso! ");
        }
        else
        {
            Console.WriteLine("Musica não encontrada na lista!");
        }

        Console.ReadKey();
        Console.Clear();
    }
}