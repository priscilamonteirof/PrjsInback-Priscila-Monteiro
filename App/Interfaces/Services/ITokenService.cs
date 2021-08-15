using Domain.Models;
using System;

namespace App.Interfaces
{
    public interface ITokenService : IDisposable
    {
        public Token GenerateToken(User user);
    }
}
