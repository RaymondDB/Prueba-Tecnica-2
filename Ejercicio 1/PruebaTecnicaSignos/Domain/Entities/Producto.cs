namespace PruebaTecnicaSignos.Domain.Entities
{

    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

        public int UnidadId { get; set; }
        public UnidadMedida? UnidadMedida { get; set; }

    }

}
