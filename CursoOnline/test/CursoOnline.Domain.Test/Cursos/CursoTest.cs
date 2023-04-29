using CursoOnline.Domain.Enums;
using CursoOnline.Domain.Test.Utils;
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
                PublicoAlvo = PublicoAlvo.Estudante,
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

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Curso_NomeVazioOuNulo_RetornaArgumentException(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Curso de Back-end",
                CargaHoraria = (double)200,
                PublicoAlvo = PublicoAlvo.Empregado,
                Valor = (decimal)500.50
            };

            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Curso_CargaHorariaMenorQue1_RetornaArgumentException(double cargaHorariaInvalida)
        {
            string mensagemError = "Parâmetros inválidos.";
            var cursoEsperado = new
            {
                Nome = "Curso de Back-end",
                CargaHoraria = (double)200,
                PublicoAlvo = PublicoAlvo.Empregado,
                Valor = (decimal)500.50
            };

            // Antes do 'AssertExtension'
            //var mensagemErrorDominio = Assert.Throws<ArgumentException>(() =>
            //                            new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;
            //Assert.Equal(mensagemErrorDominio, mensagemError);

            Assert.Throws<ArgumentException>(() => 
                        new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ValidarMensagem(mensagemError);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Curso_ValorMenorQue1_RetornaArgumentException(decimal valorInvalido)
        {
            string mensagemError = "Parâmetros inválidos.";
            var cursoEsperado = new
            {
                Nome = "Curso de Back-end",
                CargaHoraria = (double)200,
                PublicoAlvo = PublicoAlvo.Empregado,
                Valor = (decimal)500.50
            };

            var mensagemErrorDominio = Assert.Throws<ArgumentException>(() =>
                                        new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido)).Message;

            Assert.Equal(mensagemErrorDominio, mensagemError);
        }
    }
}