using System;

namespace Domain.Exceptions
{
    public abstract class NaoEncontradoException : Exception
    {
        /// <inheritdoc/>
        protected NaoEncontradoException(string message) : base(message)
        {
        }
    }
}
