using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using PasswordValidatorAPI.Models;


namespace PasswordValidatorAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        [HttpGet("healthcheck")]
        [SwaggerOperation(Summary = "HealthCheck", Description = "Verifica se API está funcionando.")]
        public string HealthCheck()
        {
            return "OK";
        }


        [HttpPost("validate")]
        [SwaggerOperation(Summary = "Solicitar Calculo de Tarifa",
            Description = "Fornece o valor de tarifa para um determinado serviço e conta.")]
        [SwaggerResponse(200, Description = "Modelo de Senha aceito", Type = typeof(ResponsePassword))]
        [SwaggerResponse(422, Description = "Senha Inválida", Type = typeof(ResponsePassword))]
        [SwaggerResponse(500, Description = "Erro interno do servidor")]
        public async Task<IActionResult> Post([FromBody] RequestPassword request)
        {
            return Ok(new ResponsePassword(true));
        }
    }
}