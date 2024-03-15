using Microsoft.Identity.Client;
using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

internal class AtualizarMusica : Menu
{
    public override void Executar(MusicaDAL musicaDAL)
    {
        var context = new ScreenSoundContext();
        var musicaDALL = new MusicaDAL(context);

        base.Executar(musicaDAL);
        ExibirTituloDaOpcao("Exibindo todas as musicas registrados na nossa aplicação");


        foreach (var music in musicaDAL.ListarMusica())
        {
            Console.WriteLine($"Musicas: {music.Nome}");
        }

        Console.WriteLine("Escolha uma musica para atualiza-lá: ");
        string nomeMusica = Console.ReadLine()!;

        Console.WriteLine("Escolha um Ano de Lancamento para atualiza-la? ");
        string AnolancamentoMusica = Console.ReadLine()!;

        // Encontrar a musica na lista
        var musicaAtualizar = musicaDAL.ListarMusica().FirstOrDefault(musica => musica.Nome.Equals(nomeMusica));
        var anoLancamentoAtualizar = musicaDAL.ListarMusica().FirstOrDefault(musica => musica.AnoLancamento.Equals(AnolancamentoMusica));
        if (musicaAtualizar != null)
        {
            
            Console.WriteLine("Musica Encontrada");

            Console.WriteLine("Para qual nome você deseja estar atualizando esta musica? ");
            string nomeMusicaNova = Console.ReadLine()!;
            Console.WriteLine("Para qual nome você deseja estar atualizando este ano de lancamento? ");
            string anoLancamentoMusicaNova = Console.ReadLine()!;

            musicaDAL.Deletar(musicaAtualizar);
            musicaDAL.Deletar(anoLancamentoAtualizar);

            //var novaMusica = new Musica(nomeMusicaNova, anoLancamentoMusicaNova);

            //musicaDAL.Atualizar(novaMusica);

            Console.WriteLine("Musica Atualizada com Sucesso!");

        }
        else
        {
            Console.WriteLine("Musica não encontrada!");
        }

        Console.ReadKey();
        Console.Clear();
    }
}