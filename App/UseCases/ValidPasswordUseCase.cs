using App.Interfaces;
using App.Models;
using System;

namespace App.UseCases
{
    public class ValidPasswordUseCase : IValidPasswordUseCase
    {
        private bool disposedValue;
        private readonly IPasswordService passwordService;

        public ValidPasswordUseCase(
            IPasswordService passwordService
        )
        {
            this.passwordService = passwordService;
        }

        public ValidPasswordResponse Execute(string senha)
        {
            var result = passwordService.IsPasswordValid(senha);

            return new ValidPasswordResponse
            {
                SenhaValida = result
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
