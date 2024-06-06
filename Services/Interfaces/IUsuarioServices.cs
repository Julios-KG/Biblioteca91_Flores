using Domain.DTO;
using Domain.Entities;

namespace WebAPI_APPINT.Services.Interfaces
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> ObtenerUsuarios();
        public Task<Response<Usuario>> ObtenerUsuario(int id);
        public Task<Response<Usuario>> CrearUsuario(UsuarioResponsive request);
        public Task<Response<int>> UpdateUsuario(int id, UsuarioResponsive request);
        public Task<Response<int>> DeleteUsuario(int id);
    }
}
