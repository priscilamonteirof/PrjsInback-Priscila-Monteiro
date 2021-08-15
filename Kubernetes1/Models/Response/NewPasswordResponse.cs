using App.Models;

namespace Api.Models
{
    public class NewPasswordResponse
    {
        public string Senha { get; set; }

        public NewPasswordResponse(CreateNewPasswordResponse response)
        {
            Senha = response.Senha;
        }
    }
}
