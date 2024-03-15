using Microsoft.Identity.Client;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
         base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro de músicas");
        
        var context = new ScreenSoundContext();
        var ArtistaDAL = new ArtistaDAL(context);
        var MusicaDAL = new MusicaDAL(context);


        foreach (var artits in artistaDAL.Listar())
        {
            Console.WriteLine($"Artistas: {artits.Nome}");

        }

        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;

        var verifica = artistaDAL.Listar().FirstOrDefault(artista => artista.Nome.Equals(nomeDoArtista));

        if (verifica is not null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento: ");
            string anoLancamentoMusica = Console.ReadLine()!;
            
            //MusicaDAL.Adicionar(new Musica(tituloDaMusica, anoLancamentoMusica));
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            Thread.Sleep(4000);
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
