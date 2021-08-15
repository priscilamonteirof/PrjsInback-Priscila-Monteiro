using Domain.Exceptions;
using Domain.Models;
using Infra.Interfaces;
using Infra.Repository;
using Xunit;

namespace Tests.Infra
{
    public class UserRepositoryTest
    {
        private readonly IUserRepository repository;

        public UserRepositoryTest()
        {
            repository = new UserRepository();
        }

        [Theory]
        [InlineData("usuario", "senha")]
        [InlineData("spiderman", "marvel")]
        public void DeveRetornarErroCasoUsuarioNaoEncontrado(string usuario, string senha)
        {
            Assert.Throws<UsuarioInvalidoException>(() =>
              repository.Get(usuario, senha)
           );
        }

        [Theory]
        [InlineData("thor", "123")]
        [InlineData("hulk", "123")]
        public void DeveRetornarUserCasoUsuarioValidado(string usuario, string senha)
        {
            var response = repository.Get(usuario, senha);

            Assert.NotNull(response);
            Assert.Equal(usuario, response.UserName);
        }

    }
}
