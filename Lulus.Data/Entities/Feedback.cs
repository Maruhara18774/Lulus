using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class Feedback
    {
        public int Feedback_ID { get; set; }

        public int Feedback_Rating { get; set; }

        public string Feedback_Title { get; set; }

        public string Feedback_Content { get; set; }

        public string User_ID { get; set; }
        public DateTime CreatedDate { get; set; }

        public int Product_ID { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
