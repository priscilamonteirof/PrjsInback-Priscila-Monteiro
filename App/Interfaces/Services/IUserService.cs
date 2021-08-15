using Domain.Models;
using System;

namespace App.Interfaces
{
    public interface IUserService : IDisposable
    {
        public User ValidateUser(string username, string password);
    }
}
