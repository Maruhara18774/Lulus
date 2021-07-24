using Lulus.BAL.Catalog.Feedbacks.Interfaces;
using Lulus.Data.EF;
using Lulus.Data.Entities;
using Lulus.ViewModels.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly LulusDBContext _context;

        public FeedbackService(LulusDBContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateFeedback(CreateFeedbackRequest request)
        {
            var feedback = new Feedback()
            {
                Feedback_Rating = request.Star,
                Feedback_Title = request.Title,
                Feedback_Content = request.Content,
                User_ID = request.UserID,
                Product_ID = request.ProductID,
                CreatedDate = DateTime.Now
            };
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
