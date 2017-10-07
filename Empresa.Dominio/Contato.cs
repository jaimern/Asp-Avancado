using System.ComponentModel.DataAnnotations;

namespace Empresa.Dominio
{
    public class Contato
    {

        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Assunto { get; set; }
        [Required]
        public string Mensagem { get; set; }

    }
}
