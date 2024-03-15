using ScreenSound.Banco;

namespace ScreenSound.Modelos
{
    public class Musica
    {
        
        public Musica(string nome)
        {
            Nome = nome;
                     
            
        }

        public string Nome { get; set; }
        public int Id { get; set; }
        public int? AnoLancamento { get; set; }
        public virtual Artista? Artista { get; set; }

        public void ExibirFichaTecnica()
        {
            var context = new ScreenSoundContext();
            var musicaDAL = new MusicaDAL(context);

            foreach (var artirts in musicaDAL.ListarMusica())
            {
                Console.WriteLine($"Nome: {artirts.Nome}");
            }
        }

        public override string ToString()
        {
            return @$"Id: {Id}
            Nome: {Nome}";
        }
    }
}
