using Api.Controllers;
using Api.Models;
using App.Interfaces;
using App.UseCases;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;

namespace Tests.Api
{
    public class PasswordControllerTest
    {
        private readonly HttpContext httpContext;
        private readonly PasswordController controller;
        private readonly IPasswordService service;
        private readonly IValidPasswordUseCase validUseCase;
        private readonly ICreateNewPasswordUseCase createUseCase;

        public PasswordControllerTest()
        {
            httpContext = Substitute.For<HttpContext>();
            controller = new PasswordController();
            controller.ControllerContext.HttpContext = httpContext;
            service = Substitute.For<IPasswordService>();
            validUseCase = new ValidPasswordUseCase(service);
            createUseCase = new CreateNewPasswordUseCase(service);
        }

        [Theory]
        [InlineData("L4mLEOps@i9FpFF")]
        [InlineData("qg2sb-8iwguKR#2")]
        [InlineData("9lB95pqELh-Mnr6")]
        public void DeveRetornarTrueCasoSenhaValida(string senha)
        {
            var request = new PasswordRequest { Senha = senha };

            service.IsPasswordValid(senha).ReturnsForAnyArgs(true);

            var response = controller.ValidatePassword(request, validUseCase);

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
            var request = new PasswordRequest { Senha = senha };

            service.IsPasswordValid(senha).ReturnsForAnyArgs(false);

            var response = controller.ValidatePassword(request, validUseCase);

            Assert.False(response.SenhaValida);
        }

        [Fact]
        public void DeveCriarSenhaValida()
        {
            string createNew = "9lB95pqELh-Mnr6";

            service.CreateNewPassword().ReturnsForAnyArgs(createNew);

            var response = controller.CreatePassword(createUseCase);

            Assert.NotEmpty(response.Senha);
        }
    }
}
