using Review.Domain.Models;

namespace Review.Domain.Interfaces
{
    public interface IFeedbackService
    {
        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns></returns>
        Task<List<Feedback>?> GetByProductIdAsync(int productId);

        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        Task<Feedback?> TryGetByIdAsync(int feedbackId);

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <returns></returns>
        Task TryToDeleteAsync(int feedbackId);

        Task<bool> AddFeedback(AddFeedbackModel newFeedback);
    }
}
