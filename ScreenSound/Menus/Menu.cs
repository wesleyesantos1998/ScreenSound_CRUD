using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    //Metodo Virtual --> Seria um metodo que pode ser sobrescrito. 
    public virtual void Executar(ArtistaDAL artistaDAL)
    {
        Console.Clear();
    }

    public virtual void Executar(MusicaDAL musicaDAL)
    {
        Console.Clear();
    }


}
