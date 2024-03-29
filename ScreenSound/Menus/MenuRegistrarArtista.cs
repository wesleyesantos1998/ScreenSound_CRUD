﻿using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarArtista : Menu
{

    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro dos Artistas");
        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        Console.Write("Digite a bio do artista que deseja registrar: ");
        string bioDoArtista = Console.ReadLine()!;
        //Artista artista = new Artista(nomeDoArtista, bioDoArtista);
        //artistasRegistrados.Add(nomeDoArtista, artista);

        var context = new ScreenSoundContext();
        var ArtistaDAL = new ArtistaDAL(context);
        ArtistaDAL.Adicionar(new Artista(nomeDoArtista, bioDoArtista));

        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(2000);
        Console.Clear(); 
    }
}
