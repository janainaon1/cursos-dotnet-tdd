using CursoOnline.Domain;
using Xunit;

namespace CursoOnline.Domain.Test.Cursos
{
    public class CursoTest
    {
        [Fact(DisplayName = "CriacaoDoCurso")]
        public void CriarCurso()
        {
            string nome = "Curso de TDD";
            double cargaHoraria = 80;
            string publicoAlvo = "Estudante";
            decimal valor = 100;

            var cursoParaCriar = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            Assert.Equal(nome, cursoParaCriar.Nome);
            Assert.Equal(cargaHoraria, cursoParaCriar.CargaHoraria);
            Assert.Equal(publicoAlvo, cursoParaCriar.PublicoAlvo);
            Assert.Equal(valor, cursoParaCriar.Valor);
        }
    }
}
