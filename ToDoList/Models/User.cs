using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(4, 8, ErrorMessage = "A senha tem que ter no minimo 4 digitos e no maximo 8")]
        public string Senha { get; set; }
    }
}
