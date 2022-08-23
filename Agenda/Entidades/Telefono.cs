namespace Agenda.Entidades
{
    public class Telefono
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int ContactoId { get; set; }
        public Contacto contacto { get; set; }
    }
}
