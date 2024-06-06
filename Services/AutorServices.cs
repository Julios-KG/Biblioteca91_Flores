using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI_APPINT.Context;
using WebAPI_APPINT.Services.Interfaces;

namespace WebAPI_APPINT.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDbContext _context;
        public AutorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new(), commandType: CommandType.StoredProcedure);
                response = result.ToList();
                return new Response<List<Autor>> ( response );
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un Error :c" + ex.Message);
            }
        }
    }
}
