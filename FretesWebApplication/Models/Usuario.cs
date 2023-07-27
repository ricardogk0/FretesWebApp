using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FretesWebApplication.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("salt")]
        public string? Salt { get; set; }

        [Column("tipo_usuario")]
        [Display(Name = "Tipo de Usuário")]
        public int TipoUsuario { get; set; }
    }
}
