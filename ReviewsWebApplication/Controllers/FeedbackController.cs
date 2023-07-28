using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Review.Domain.Helper;
using Review.Domain.Interfaces;
using Review.Domain.Models;

namespace ReviewsWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FeedbackController : ControllerBase
    {

        private readonly ILogger<FeedbackController> _logger;
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackService feedbackService)
        {
            _logger = logger;
            _feedbackService = feedbackService;
        }

        /// <summary>
        /// Получение всех отзывов по продукту
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllByProductId")]
        public async Task<ActionResult<List<Feedback>>> GetAllByProductIdAsync(int productId)
        {
            try
            {
                var result = await _feedbackService.GetByProductIdAsync(productId) ?? new List<Feedback>();
                return Ok(result.ToFeedbacksViewModel());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Получение отзыва
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<ActionResult<Feedback>> GetByIdAsync(int feedbackId)
        {
            try
            {
                var result = await _feedbackService.TryGetByIdAsync(feedbackId);
                return Ok(result.ToFeedbackViewModel());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Удаление отзыва по productId
        /// </summary>
        /// <returns></returns>
        
        [HttpDelete("Delete")]
        public async Task<ActionResult<Feedback>> DeleteAsync(int feedbackId)
        {
            try
            {
                await _feedbackService.TryToDeleteAsync(feedbackId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        
        [HttpPost("AddFeedback")]
        public async Task<ActionResult<Feedback>> AddFeedback(AddFeedbackModel newFeedback)
        {
            var result = await _feedbackService.AddFeedback(newFeedback);
            if (result)
            {
                return Ok(new { Message = "Added" });
            }
            return BadRequest(new { Message = "Not Added" });
        }
    }
}