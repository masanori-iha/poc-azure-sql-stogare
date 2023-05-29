using System.ComponentModel.DataAnnotations;

namespace bancoAzure.Models
{
    public class UsuarioCreate
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(255, ErrorMessage = "Quantidade máxima de caracteres é 255")]
        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}
