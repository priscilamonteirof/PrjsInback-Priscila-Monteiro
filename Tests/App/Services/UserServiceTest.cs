using App.Interfaces;
using App.Services;
using Domain.Exceptions;
using Domain.Models;
using Infra.Interfaces;
using NSubstitute;
using Xunit;

namespace Tests.App.Services
{
    public class UserServiceTest
    {
        private readonly IUserRepository repository;
        private readonly IUserService service;

        public UserServiceTest()
        {
            repository = Substitute.For<IUserRepository>();
            service = new UserService(repository);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("usuario", "")]
        [InlineData("", "senha")]
        public void DeveRetornarErroCasoUsuarioSenhaEstejamVazios(string usuario, string senha)
        {
            Assert.Throws<UsuarioSenhaObrigatoriosException>(() =>
               service.ValidateUser(usuario, senha) 
            );
        }

        [Theory]
        [InlineData("usuario", "senha")]
        [InlineData("spiderman", "marvel")]
        public void DeveRetornarErroCasoUsuarioNaoEncontrado(string usuario, string senha)
        {
            repository.Get(usuario, senha)
                .Returns(x => throw new UsuarioInvalidoException(usuario));

            Assert.Throws<UsuarioInvalidoException>(() =>
              service.ValidateUser(usuario, senha)
           );
        }

        [Theory]
        [InlineData("thor", "123")]
        [InlineData("hulk", "123")]
        public void DeveRetornarUserCasoUsuarioValidado(string usuario, string senha)
        {
            var user = new User(usuario, senha, usuario + "@email.com");

            repository.Get(usuario, senha)
                 .Returns(user);

            var response = service.ValidateUser(usuario, senha);

            Assert.Equal(usuario, response.UserName);
        }
    }
}
