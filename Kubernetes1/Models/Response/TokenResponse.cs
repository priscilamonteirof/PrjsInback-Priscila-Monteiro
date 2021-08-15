using App.Models;
using System;

namespace Api.Models
{
    public class TokenResponse
    {
        public string Usuario { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public string Mensagem { get; set; }

        public TokenResponse(AuthenticationResponse response) 
        {
            Usuario = response.Usuario;
            Autenticado = response.Autenticado;
            Token = response.Token;
            DataExpiracao = response.DataExpiracao;
            Mensagem = response.Mensagem;
        }
    }
}
