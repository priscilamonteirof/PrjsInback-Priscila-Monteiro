namespace Domain.Exceptions
{
    public class UsuarioInvalidoException : NaoEncontradoException
    {
        public UsuarioInvalidoException(string usuario) : base($"Usuário {usuario} ou senha inválidos.")
        {
        }
    }
}
