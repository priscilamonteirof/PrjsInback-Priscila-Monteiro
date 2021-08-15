using App.Models;
using System;

namespace App.Interfaces
{
    public interface ICreateNewPasswordUseCase : IDisposable
    {
        public CreateNewPasswordResponse Execute();
    }
}
