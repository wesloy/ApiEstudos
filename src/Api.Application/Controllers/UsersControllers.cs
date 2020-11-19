using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [ApiController] //Determina que será uma API e não um MVC
    //determinando como é chamada os metodos (http://localhost:5000/api/users)    
    [Route("api/[controller]")]


    public class UsersControllers : ControllerBase //Vindo do MVC
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService service)
        {
            if (!ModelState.IsValid)
            {
                //Verificação se a entrada do usuário é válida para o método
                return BadRequest(ModelState); //400 solicitação inválida
            }

            try
            {
                return Ok(await service.GetAll()); //Retorno da Interface, injetada no método
            }
            catch (ArgumentException e) //ArgumentException é usado para tratar Controllers
            {
                //Enviando o erro para o usuário, visto ser a última camada do sistema
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
