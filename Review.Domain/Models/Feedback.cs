using Review.Domain.Helper;

namespace Review.Domain.Models
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Id отзыва
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id пользователя, оставившего отзыв
        /// </summary>
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Login { get; set; }
        /// <summary>
        /// Текст отзыва
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Оценка (количество звезд)
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }
        public Statuses Status { get; set; }

    }
}
