using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaseCasa.Models
{
    public class CasaModel
    {
        public CasaModel(){
            Cuartos=new List<CuartoModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCasa { get; set; }
        public int NodeRejas { get; set; }
        public bool TieneJardin { get; set; }
        public bool TienePorche { get; set; }
        public bool TienePiscina { get; set; }
        public required string Color { get; set; }

        public List<CuartoModel> Cuartos { get; set; } = new List<CuartoModel>();
        //public TipoCuartoModel TipoCuarto { get; set; } = null!;
        //public TipoCuartoModel TipoCuarto { get; } = null!;

    }
}
