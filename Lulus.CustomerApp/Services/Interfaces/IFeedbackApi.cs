using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lulus.ViewModels.Feedbacks;

namespace Lulus.CustomerApp.Services.Interfaces
{
    public interface IFeedbackApi
    {
        Task<bool> CreateFeedback(CreateFeedbackRequest request);
    }
}
