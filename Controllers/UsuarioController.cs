using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPI_APPINT.Services.Interfaces;

namespace WebAPI_APPINT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices) 
        { 
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLista()
        {
            var result = await _usuarioServices.ObtenerUsuarios();
            return Ok(result);
        }

        [HttpGet("int:id")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var result = await _usuarioServices.ObtenerUsuario(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioResponsive request)
        {
            var result = await _usuarioServices.CrearUsuario(request);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioResponsive request)
        {
            var response = await _usuarioServices.UpdateUsuario(id, request);

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
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var response = await _usuarioServices.DeleteUsuario(id);

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
