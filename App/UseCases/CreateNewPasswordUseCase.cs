using App.Interfaces;
using App.Models;
using System;

namespace App.UseCases
{
    public class CreateNewPasswordUseCase : ICreateNewPasswordUseCase
    {
        private bool disposedValue;
        private readonly IPasswordService passwordService;

        public CreateNewPasswordUseCase(
            IPasswordService passwordService
        )
        {
            this.passwordService = passwordService;
        }

        public CreateNewPasswordResponse Execute()
        {
            var result = passwordService.CreateNewPassword();

            return new CreateNewPasswordResponse
            {
                Senha = result
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    passwordService?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
