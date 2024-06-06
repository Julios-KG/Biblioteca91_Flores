using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebAPI_APPINT.Context;
using WebAPI_APPINT.Services.Interfaces;

namespace WebAPI_APPINT.Services
{
    public class RegistroServices : IRegistroServices
    {
        private readonly ApplicationDbContext _context;
        public RegistroServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de Usuarios
        public async Task<Response<List<Registro>>> ObtenerRegistros()
        {
            try
            {
                List<Registro> response = await _context.Registros.Include(x => x.Tipos).ToListAsync();

                return new Response<List<Registro>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un Error" + ex.Message);
            }
        }

        public async Task<Response<Registro>> ObtenerRegistro(int id)
        {
            try
            {
                Registro res = await _context.Registros.FirstOrDefaultAsync(x => x.PkRegistro == id);

                return new Response<Registro>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un Error" + ex.Message);
            }
        }

        public async Task<Response<Registro>> CrearRegistro(RegistroResponsive request)
        {
            try
            {
                Registro registro = new Registro()
                {
                    Fecha = request.Fecha,
                    Descripcion = request.Descripcion,
                    Cantidad = request.Cantidad,
                    FkTipo = request.FkTipo,
                };

                _context.Registros.Add(registro);
                await _context.SaveChangesAsync();

                return new Response<Registro>(registro);

                //usuario.Nombre = request.Nombre;
                //usuario.User = request.User;
                //usuario.Password = request.Password;
                //usuario.FkRol = request.FkRol;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un Error" + ex.Message);
            }
        }
        public async Task<Response<int>> UpdateRegistro(int id, RegistroResponsive request)
        {
            try
            {
                var registro = await _context.Registros.FindAsync(id);
                if (registro == null)
                {
                    return new Response<int>("Registro no encontrado");
                }

                registro.Fecha = request.Fecha;
                registro.Descripcion = request.Descripcion;
                registro.Cantidad = request.Cantidad;
                registro.FkTipo = request.FkTipo;

                _context.Registros.Update(registro);
                await _context.SaveChangesAsync();

                return new Response<int>(registro.PkRegistro, registro.Descripcion);
            }
            catch (Exception ex)
            {
                return new Response<int>("Ocurrió un error: " + ex.Message);
            }
        }
        public async Task<Response<int>> DeleteRegistro(int id)
        {
            try
            {
                var registro = await _context.Registros.FindAsync(id);
                if (registro == null)
                {
                    return new Response<int>("Registro no encontrado");
                }

                _context.Registros.Remove(registro);
                await _context.SaveChangesAsync();

                return new Response<int>(registro.PkRegistro, registro.Descripcion);
            }
            catch (Exception ex)
            {
                return new Response<int>("Ocurrió un error: " + ex.Message);
            }
        }
    }
}
