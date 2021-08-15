using System;

namespace App.Interfaces
{
    public interface IPasswordService : IDisposable
    {
        public bool IsPasswordValid(object value);

        public string CreateNewPassword();
    }
}
