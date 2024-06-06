using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPI_APPINT.Services.Interfaces;

namespace WebAPI_APPINT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroController : ControllerBase
    {
        public readonly IRegistroServices _registroServices;
        public RegistroController(IRegistroServices registroServices)
        {
            _registroServices = registroServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLista()
        {
            var result = await _registroServices.ObtenerRegistros();
            return Ok(result);
        }

        [HttpGet("int:id")]
        public async Task<IActionResult> ObtenerRegistro(int id)
        {
            var result = await _registroServices.ObtenerRegistro(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearRegistro([FromBody] RegistroResponsive request)
        {
            var result = await _registroServices.CrearRegistro(request);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarRegistro(int id, [FromBody] RegistroResponsive request)
        {
            var response = await _registroServices.UpdateRegistro(id, request);

            if (response.Success)
            {
                return Ok(response.Result);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRegistro(int id)
        {
            var response = await _registroServices.DeleteRegistro(id);

            if (response.Success)
            {
                return NoContent(); // NoContent corresponde a 204 No Content
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
