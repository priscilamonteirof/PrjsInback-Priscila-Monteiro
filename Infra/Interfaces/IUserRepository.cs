using Domain.Models;
using System;

namespace Infra.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        public User Get(string username, string password);
    }
}
