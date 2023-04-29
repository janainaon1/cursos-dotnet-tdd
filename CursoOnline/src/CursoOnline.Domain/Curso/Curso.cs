namespace CursoOnline.Domain
{
    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }

        public Curso(string nome, double cargaHoraria, string publicoAlvo, decimal valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }
    }
}
