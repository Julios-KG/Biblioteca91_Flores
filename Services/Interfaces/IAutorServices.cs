using Domain.Entities;

namespace WebAPI_APPINT.Services.Interfaces
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
    }
}
