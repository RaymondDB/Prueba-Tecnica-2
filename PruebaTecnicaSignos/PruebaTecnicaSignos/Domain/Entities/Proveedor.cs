namespace PruebaTecnicaSignos.Domain.Entities
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
