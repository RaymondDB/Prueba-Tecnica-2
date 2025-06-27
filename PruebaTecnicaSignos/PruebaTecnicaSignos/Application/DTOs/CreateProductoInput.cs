namespace PruebaTecnicaSignos.Application.DTOs
{
    public class CreateProductoInput
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public int UnidadId { get; set; }
    }
}
