using App.Interfaces;
using App.UseCases;
using Domain.Exceptions;
using Domain.Models;
using NSubstitute;
using System;
using Xunit;

namespace Tests.App.UseCases
{
    public class AuthenticationUseCaseTest
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IAuthenticationUseCase useCase;

        public AuthenticationUseCaseTest()
        {
            userService = Substitute.For<IUserService>();
            tokenService = Substitute.For<ITokenService>();
            useCase = new AuthenticationUseCase(userService, tokenService);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("usuario", "")]
        [InlineData("", "senha")]
        public void DeveRetornarErroCasoUsuarioSenhaEstejamVazios(string usuario, string senha)
        {
            userService.ValidateUser(usuario, senha)
                .Returns(x => throw new UsuarioSenhaObrigatoriosException());

            var response = useCase.Execute(usuario, senha);

            Assert.Equal($"Usuário e/ou senha obrigatórios.", response.Mensagem);
            Assert.False(response.Autenticado);
        }

        [Theory]
        [InlineData("usuario", "senha")]
        [InlineData("spiderman", "marvel")]
        public void DeveRetornarErroCasoUsuarioNaoEncontrado(string usuario, string senha)
        {
            userService.ValidateUser(usuario, senha)
                .Returns(x => throw new UsuarioInvalidoException(usuario));

            var response = useCase.Execute(usuario, senha);

            Assert.Equal($"Usuário {usuario} ou senha inválidos.", response.Mensagem);
            Assert.False(response.Autenticado);
        }

        [Theory]
        [InlineData("thor", "123")]
        [InlineData("hulk", "123")]
        public void DeveRetornarTokenCasoUsuarioValidado(string usuario, string senha)
        {
            var user = new User(usuario, senha, usuario + "@email.com");
            var token = new Token(Guid.NewGuid().ToString(), 300, DateTime.Now.AddMinutes(5));

            userService.ValidateUser(usuario, senha).ReturnsForAnyArgs(user);

            tokenService.GenerateToken(user).ReturnsForAnyArgs(token);

            var response = useCase.Execute(usuario, senha);

            Assert.NotEmpty(response.Token);
            Assert.True(response.Autenticado);
        }
    }
}
