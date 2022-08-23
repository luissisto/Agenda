namespace Agenda.Entidades
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int UsuarioId { get; set; }
        public Usuario usuario { get; set; }
    }
}
