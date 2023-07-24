using FretesWebApplication.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FretesWebApplication.Models
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Key]
        [Column("id_veiculo")]
        public int IdVeiculo { get; set; }

        [Column("denominacao")]
        [Display(Name = "Denominação")]
        public string Denominacao { get; set; }

        [Column("tipo_veiculo")]
        [Display(Name = "Tipo do Veículo")]
        public TipoVeiculo TipoVeiculo { get; set; }

        [Column("peso_veiculo")]
        [Display(Name = "Peso Veículo")]
        public double PesoVeiculo { get; set; }
    }
}
