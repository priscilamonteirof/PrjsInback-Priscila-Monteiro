using App.Interfaces;
using App.Models;
using System;

namespace App.UseCases
{
    public class AuthenticationUseCase: IAuthenticationUseCase
    {
        private bool disposedValue;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public AuthenticationUseCase(
            IUserService userService,
            ITokenService tokenService
        )
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        public AuthenticationResponse Execute(string usuario, string senha)
        {
            try
            {
                var user = userService.ValidateUser(usuario, senha);

                var token = tokenService.GenerateToken(user);

                return new AuthenticationResponse
                {
                    Token = token.AccessToken,
                    DataExpiracao = token.ExpiresAt,
                    Usuario = user.UserName,
                    Autenticado = true,
                    Mensagem = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new AuthenticationResponse
                {
                    Autenticado = false,
                    Mensagem = ex.Message
                };
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    userService?.Dispose();
                    tokenService?.Dispose();
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
