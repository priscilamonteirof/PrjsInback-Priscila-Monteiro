using Domain.Exceptions;
using Domain.Models;
using Infra.Interfaces;
using Infra.Mock;
using System;
using System.Linq;

namespace Infra.Repository
{
    public class UserRepository: IUserRepository
    {
        private bool disposedValue;

        public User Get(string username, string password)
        {
            var user = UserMock.GetAll().Where(u => u.UserName.ToLower() == username.ToLower() && u.Password == password);
            if (!user.Any())
                throw new UsuarioInvalidoException(username);
            
            return user.FirstOrDefault();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //
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
