using App.Interfaces;
using App.UseCases;
using NSubstitute;
using Xunit;

namespace Tests.App.UseCases
{
    public class ValidPasswordUseCaseTest
    {
        private readonly IPasswordService passwordService;
        private readonly ValidPasswordUseCase useCase;

        public ValidPasswordUseCaseTest()
        {
            passwordService = Substitute.For<IPasswordService>();
            useCase = new ValidPasswordUseCase(passwordService);
        }

        [Theory]
        [InlineData("L4mLEOps@i9FpFF")]
        [InlineData("qg2sb-8iwguKR#2")]
        [InlineData("9lB95pqELh-Mnr6")]
        public void DeveRetornarTrueCasoSenhaValida(string senha)
        {
            passwordService.IsPasswordValid(senha).ReturnsForAnyArgs(true);

            var response = useCase.Execute(senha);

            Assert.True(response.SenhaValida);
        }

        [Theory]
        [InlineData("Tpi@v6")]
        [InlineData("9lb95pqelh-mnr6")]
        [InlineData("85GMMB7JNHB@VMD")]
        [InlineData("qg2sb08iwguKR12")]
        [InlineData("L4mLEOps@i9FFFF")]
        public void DeveRetornarFalseCasoSenhaInvalida(string senha)
        {
            passwordService.IsPasswordValid(senha).ReturnsForAnyArgs(false);

            var response = useCase.Execute(senha);

            Assert.False(response.SenhaValida);
        }

    }
}
