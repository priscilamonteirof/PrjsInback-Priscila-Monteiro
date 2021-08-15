using App.Interfaces;
using App.Services;
using Domain.Models;
using Xunit;

namespace Tests.App.Services
{
    public class TokenServiceTest
    {
        private readonly ITokenService service;

        public TokenServiceTest()
        {
            service = new TokenService();
        }

        [Theory]
        [InlineData("thor", "123")]
        [InlineData("hulk", "123")]
        public void DeveRetornarTokenCasoUsuarioValido(string usuario, string senha)
        {
            var user = new User(usuario, senha, usuario + "@email.com");

            var response = service.GenerateToken(user);

            Assert.NotNull(response);
        }
    }
}
