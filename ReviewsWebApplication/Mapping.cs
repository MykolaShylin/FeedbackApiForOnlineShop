using Review.Domain.Models;
using ReviewsWebApplication.Models;

namespace ReviewsWebApplication
{
    public static class Mapping
    {
        public static List<FeedbackViewModel> ToFeedbacksViewModel(this List<Feedback> feedbacks)
        {
            var feedbacksViewModel = new List<FeedbackViewModel>();
            foreach(var feedback in feedbacks)
            {
                feedbacksViewModel.Add(ToFeedbackViewModel(feedback));
            }
            return feedbacksViewModel;
        }

        public static FeedbackViewModel ToFeedbackViewModel(this Feedback feedback)
        {
            return new FeedbackViewModel
            {
                Id = feedback.Id,
                UserId = feedback.UserId,
                UserName= feedback.UserName,
                Login = feedback.Login,
                Text = feedback.Text,
                Grade = feedback.Grade,
                CreateDate = feedback.CreateDate,
            };
        }
    }
}
