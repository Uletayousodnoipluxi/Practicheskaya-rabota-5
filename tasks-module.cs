using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Необходимо задать название задачи.")]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public bool IsCompleted { get; set; }
    }
}
