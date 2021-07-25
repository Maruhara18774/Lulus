using Lulus.BAL.Catalog.Feedbacks.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lulus.ViewModels.Feedbacks;

namespace Lulus.BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeedback(CreateFeedbackRequest request)
        {
            var result = await _feedbackService.CreateFeedback(request);
            return Ok(result);
        }
    }
}
