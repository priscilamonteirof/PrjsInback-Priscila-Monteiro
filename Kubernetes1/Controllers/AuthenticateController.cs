using Api.Models;
using App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        [HttpGet]
        [Route("authentication")]
        [AllowAnonymous]
        public TokenResponse Authenticate([FromBody] UserRequest request, [FromServices] IAuthenticationUseCase useCase)
        {
            var response = useCase.Execute(request.Usuario, request.Senha);

            if (!response.Autenticado)
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return new TokenResponse(response);
        }
    }
}
