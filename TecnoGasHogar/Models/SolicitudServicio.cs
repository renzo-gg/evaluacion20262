using System.ComponentModel.DataAnnotations;

namespace TecnoGasHogar.Models
{
    public class SolicitudServicio
    {
        public int Id { get; set; }
        [Required] public string Cliente { get; set; } = string.Empty;
        [Required] public string Telefono { get; set; } = string.Empty;
        [Required] public string Distrito { get; set; } = string.Empty;
        [Required] public string TipoServicio { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
