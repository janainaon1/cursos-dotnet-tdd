using ExpectedObjects;
using Xunit;

namespace CursoOnline.Domain.Test.Cursos
{
    public class CursoTest
    {
        [Fact(DisplayName = "CriacaoDoCurso")]
        public void CriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Curso de TDD",
                // Erro exemplo: CargaHoraria = 80,
                CargaHoraria = (double)80,
                PublicoAlvo = "Estudante",
                // Erro exemplo: Valor = 100
                Valor = (decimal)100
            };

            var cursoParaCriar = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(cursoParaCriar);

            // Sem a lib ExpectedObjects 
            //Assert.Equal(nome, cursoParaCriar.Nome);
            //Assert.Equal(cargaHoraria, cursoParaCriar.CargaHoraria);
            //Assert.Equal(publicoAlvo, cursoParaCriar.PublicoAlvo);
            //Assert.Equal(valor, cursoParaCriar.Valor);
        }
    }
}
