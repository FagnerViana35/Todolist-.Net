using System.ComponentModel.DataAnnotations;

namespace ToDoList.Data.Dtos.DtoListaTarefa
{
    public class ReadListaTarefaDto
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }
    }
}
