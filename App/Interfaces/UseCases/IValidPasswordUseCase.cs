using App.Models;
using System;

namespace App.Interfaces
{
    public interface IValidPasswordUseCase : IDisposable
    {
        public ValidPasswordResponse Execute(string senha);
    }
}
