using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Reflection.Metadata;

namespace ClaseCasa.Models
{
    public class CuartoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCuarto { get; set; }
        public int IdCasa { get; set; }
        public int IdTipoCuarto { get; set; }
        public required string Color { get; set; }
        public bool WcPropio { get; set; }
        public Double Medida { get; set; }
        public CasaModel CasaModel { get;} = null!; // Required reference navigation to principal
        //public TipoCuartoModel TipoCuarto { get;} = null!;
        public TipoCuartoModel TipoCuarto { get; } = null!;
    }
}


