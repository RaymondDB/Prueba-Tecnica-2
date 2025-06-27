using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaSignos.Domain.Entities
{
    public class UnidadMedida
    {
        [Key]
        public int UnidadId { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }

}
