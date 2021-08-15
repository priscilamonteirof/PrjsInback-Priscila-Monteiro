using App.Models;
using System;

namespace App.Interfaces
{
    public interface IAuthenticationUseCase : IDisposable
    {
        public AuthenticationResponse Execute(string usuario, string senha);
    }
}
