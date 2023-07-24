using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FretesWebApplication.Models
{
    [Table("conta_usuario")]
    public class ContaUsuario
    {
        [Key]
        [Column("id_conta")]
        public int IdConta { get; set; }

        [ForeignKey("Usuario")]
        [Column("id_conta_usuario")]
        public int IdContaUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }
    }
}
