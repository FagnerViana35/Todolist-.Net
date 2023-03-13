using System.ComponentModel.DataAnnotations;

namespace ToDoList.Data.Dtos.DtoListaTarefa
{
    public class CreateListaTarefaDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }
    }
}
