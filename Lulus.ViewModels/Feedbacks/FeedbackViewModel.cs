using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.ViewModels.Feedbacks
{
    public class FeedbackViewModel
    {
        public int ID { get; set; }

        public int Star { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ProductID { get; set; }
    }
}
