using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebAPI_APPINT.Migrations;
using Autor = Domain.Entities.Autor;

namespace WebAPI_APPINT.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        //Modelos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Funcion Insertar Tabla Usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Carlos",
                    User = "Usuario1",
                    Password = "123",
                    FkRol = 1
                }
            );
            //Funcion Insertar Tabla Rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa"
                }
            );

            //Funcion Insertar Tabla Autor
            modelBuilder.Entity<Autor>().HasData(
                new Autor
                {
                    PkAutor = 1,
                    Nombre = "Charly",
                    Nacionalidad = "Mexicano"
                }
            );

            //Funcion Insertar Tabla Registro
            modelBuilder.Entity<Registro>().HasData(
                new Registro
                {
                    PkRegistro = 1,
                    Fecha = "Charly",
                    Descripcion = "Mexicano",
                    Cantidad = "$1999",
                    FkTipo = 1
                }
            );
            //Funcion Insertar Tabla Tipo
            modelBuilder.Entity<Tipo>().HasData(
                new Tipo
                {
                    PkTipo = 1,
                    Nombre = "Entrada"
                }
            );
        }
    }
}
