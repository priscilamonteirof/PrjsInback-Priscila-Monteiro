using App.Interfaces;
using Domain.Exceptions;
using Domain.Models;
using Infra.Interfaces;
using System;

namespace App.Services
{
    public class UserService: IUserService
    {
        private bool disposedValue;

        private readonly IUserRepository repository;

        public UserService(
            IUserRepository repository
        )
        {
            this.repository = repository;
        }

        private User GetUser(string username, string password)
        {
            return repository.Get(username, password);
        }

        public User ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new UsuarioSenhaObrigatoriosException();

            return (GetUser(username, password));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    repository?.Dispose();
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
