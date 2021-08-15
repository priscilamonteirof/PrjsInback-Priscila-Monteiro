using Api.Models;
using App.Interfaces;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        [HttpGet]
        [Route("validate-password")]
        [Authorize]
        public PasswordValidResponse ValidatePassword([FromBody] PasswordRequest request, [FromServices] IValidPasswordUseCase useCase) 
        {
            var response = useCase.Execute(request.Senha);

            if (!response.SenhaValida)
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return new PasswordValidResponse(response);
        }

        [HttpGet]
        [Route("create-password")]
        [Authorize]
        public NewPasswordResponse CreatePassword([FromServices] ICreateNewPasswordUseCase useCase)
        {
            var response = useCase.Execute();

            return new NewPasswordResponse(response);
        }
    }
}
