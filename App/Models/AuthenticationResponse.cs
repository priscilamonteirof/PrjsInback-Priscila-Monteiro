using System;

namespace App.Models
{
    public class AuthenticationResponse
    {
        public string Usuario { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public string Mensagem { get; set; }
    }
}
