using System.ComponentModel.DataAnnotations;

namespace ClaseCasa.Models
{
    public class TipoCuartoModel
    {
        [Key]
        public int IdTipoCuarto { get; set; }
        public required string Descripcion { get; set;} = null!;
    }
}
