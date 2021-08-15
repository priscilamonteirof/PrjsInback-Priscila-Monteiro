using App.Interfaces;
using App.UseCases;
using NSubstitute;
using Xunit;

namespace Tests.App.UseCases
{
    public class CreateNewPasswordUseCaseTest
    {
        private readonly IPasswordService passwordService;
        private readonly CreateNewPasswordUseCase useCase;

        public CreateNewPasswordUseCaseTest()
        {
            passwordService = Substitute.For<IPasswordService>();
            useCase = new CreateNewPasswordUseCase(passwordService);
        }

        [Fact]
        public void DeveCriarSenhaValida()
        {
            string createNew = "9lB95pqELh-Mnr6";

            passwordService.CreateNewPassword().ReturnsForAnyArgs(createNew);

            var response = useCase.Execute();

            Assert.NotEmpty(response.Senha);
        }

    }
}
