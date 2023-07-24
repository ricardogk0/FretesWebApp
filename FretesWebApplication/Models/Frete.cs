using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FretesWebApplication.Models
{
    [Table("frete")]
    public class Frete
    {
        [Key]
        [Column("id_frete")]
        public int IdFrete { get; set; }

        [Column("distancia")]
        [Display(Name = "Distância")]
        public double Distancia { get; set; }

        [ForeignKey("Veiculo")]
        [Column("id_veiculo")]
        public int IdVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }

        [ForeignKey("Produto")]
        [Column("id_produto")]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

        [ReadOnly(true)]
        public double Taxa { get; set; }

        [Column("valor_total")]
        [Display(Name = "Valor Total")]
        [ReadOnly(true)]
        public double ValorTotal { get; set; }

    }



}
