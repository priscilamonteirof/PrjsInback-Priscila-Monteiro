namespace Domain.Exceptions
{
    public class UsuarioSenhaObrigatoriosException : NaoEncontradoException
    {
        public UsuarioSenhaObrigatoriosException() : base($"Usuário e/ou senha obrigatórios.")
        {
        }
    }
}
