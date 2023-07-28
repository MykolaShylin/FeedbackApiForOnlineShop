using System.ComponentModel.DataAnnotations;

namespace Review.Domain.Models
{
    
    public class AddFeedbackModel
    {
        
        public int ProductId { get; set; }

        
        public string UserId { get; set; }

        public string Login { get; set; }
        public string UserName { get; set; }

        public string? Text { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Оценка должна быть в пределах от 0 до 5 баллов!")]
        public int Grade { get; set; }       

    }
}
