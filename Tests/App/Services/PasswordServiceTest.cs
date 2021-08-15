using App.Interfaces;
using App.Services;
using Xunit;

namespace Tests.App.Services
{
    public class PasswordServiceTest
    {
        private readonly IPasswordService service;

        public PasswordServiceTest()
        {
            service = new PasswordService();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("senha")]
        [InlineData("Tpi@v6")]
        [InlineData("9lb95pqelh-mnr6")]
        [InlineData("85GMMB7JNHB@VMD")]
        [InlineData("qg2sb08iwguKR12")]
        [InlineData("L4mLEOps@i9FFFF")]
        public void DeveRetornarFalseCasoSenhaInvalida(string senha)
        {
            var response = service.IsPasswordValid(senha);

            Assert.False(response);
        }

        [Theory]
        [InlineData("L4mLEOps@i9FpFF")]
        [InlineData("qg2sb-8iwguKR#2")]
        [InlineData("9lB95pqELh-Mnr6")]
        public void DeveRetornarTrueCasoSenhaInvalida(string senha)
        {
            var response = service.IsPasswordValid(senha);

            Assert.True(response);
        }
    }
}
