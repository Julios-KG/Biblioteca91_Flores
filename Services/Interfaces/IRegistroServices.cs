using Domain.DTO;
using Domain.Entities;

namespace WebAPI_APPINT.Services.Interfaces
{
    public interface IRegistroServices
    {
        public Task<Response<List<Registro>>> ObtenerRegistros();
        public Task<Response<Registro>> ObtenerRegistro(int id);
        public Task<Response<Registro>> CrearRegistro(RegistroResponsive request);
        public Task<Response<int>> UpdateRegistro(int id, RegistroResponsive request);
        public Task<Response<int>> DeleteRegistro(int id);
    }
}
