using Review.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Review.Domain.Interfaces;
using System;
using Microsoft.OpenApi.Extensions;
using Review.Domain.Helper;

namespace Review.Domain.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly DataBaseContext databaseContext;
        private Random _random = new Random();
        public FeedbackService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Feedback>?> GetByProductIdAsync(int productId)
        {
            var rating = await databaseContext.Ratings.Include(x=>x.Feedbacks).FirstOrDefaultAsync(x=>x.ProductId == productId);
            return rating?.Feedbacks.Where(x=>x.Status == Statuses.Actual).ToList();
        }

        public async Task<Feedback?> TryGetByIdAsync(int feedbackId)
        {
            return await databaseContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == feedbackId && x.Status == Statuses.Actual);
        }

        public async Task TryToDeleteAsync(int feedbackId)
        {

            var feedback = await TryGetByIdAsync(feedbackId);

            if(feedback == null)
            {
                throw new NullReferenceException($"Отзыва с id = {feedbackId} не существует");
            }

            feedback.Status = Statuses.Deleted;
            await databaseContext.SaveChangesAsync();

        }
        public async Task<bool> AddFeedback(AddFeedbackModel newFeedback)
        {
            var rating = databaseContext.Ratings.Include(x => x.Feedbacks).FirstOrDefault(x => x.ProductId == newFeedback.ProductId);
            if (rating == null)
            {
                rating = new Rating
                {
                    ProductId = newFeedback.ProductId,
                    CreateDate = DateTime.UtcNow,
                    Feedbacks = new List<Feedback>()
                };

                await databaseContext.Ratings.AddAsync(rating);
            }

            var feedback = new Feedback
            {
                UserId = newFeedback.UserId,
                UserName = newFeedback.UserName,
                Login = newFeedback.Login,
                Grade = newFeedback.Grade,
                Text = newFeedback.Text,
                RatingId = rating.Id,
                Status = Statuses.Actual,
                CreateDate = DateTime.UtcNow,
            };  
            rating.Feedbacks.Add(feedback);

            try
            {
                databaseContext.Feedbacks.Add(feedback);
                await databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
