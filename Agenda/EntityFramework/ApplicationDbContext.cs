using Agenda.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace agenda.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}