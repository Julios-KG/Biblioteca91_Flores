using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebAPI_APPINT.Context;
using WebAPI_APPINT.Services.Interfaces;

namespace WebAPI_APPINT.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de Usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(x => x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un Error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> ObtenerUsuario(int id)
        {
            try
            {
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x=>x.PkUsuario == id);

                return new Response<Usuario>(res);
            }
            catch (Exception ex) 
            {
                throw new Exception("Sucedio un Error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponsive request)
        {
            try
            {
                Usuario usuario = new Usuario() 
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol,
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

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
        public async Task<Response<int>> UpdateUsuario(int id, UsuarioResponsive request)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<int>("Usuario no encontrado");
                }

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return new Response<int>(usuario.PkUsuario, usuario.Nombre);
            }
            catch (Exception ex)
            {
                return new Response<int>("Ocurrió un error: " + ex.Message);
            }
        }
        public async Task<Response<int>> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<int>("Usuario no encontrado");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<int>(usuario.PkUsuario, usuario.Nombre);
            }
            catch (Exception ex)
            {
                return new Response<int>("Ocurrió un error: " + ex.Message);
            }
        }
    }
}
