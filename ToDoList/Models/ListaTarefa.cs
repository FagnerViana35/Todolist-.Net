using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ListaTarefa
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
