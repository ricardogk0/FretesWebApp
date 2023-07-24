using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FretesWebApplication.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        [Column("id_produto")]
        public int IdProduto { get; set; }

        [Column("denominacao")]
        [Display(Name = "Denominação")]
        public string Denominacao { get; set; }

        [Column("peso_produto")]
        [Display(Name = "Peso do Produto")]
        public double PesoProduto { get; set; }
    }
}
