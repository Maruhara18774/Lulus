using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lulus.ViewModels.Feedbacks;

namespace Lulus.BAL.Catalog.Feedbacks.Interfaces
{
    public interface IFeedbackService
    {
        public Task<bool> CreateFeedback(CreateFeedbackRequest request);
    }
}
