using App.Models;

namespace Api.Models
{
    public class PasswordValidResponse
    {
        public bool SenhaValida { get; set; }

        public PasswordValidResponse(ValidPasswordResponse response)
        {
            SenhaValida = response.SenhaValida;
        }
    }
}
