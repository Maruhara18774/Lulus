
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.Data.Entities
{
    public class User: IdentityUser
    {        
        public string Customer_FirstName { get; set; }
        public string Customer_LastName { get; set; }
        public string Customer_Address { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<Feedback> Feedbacks { get; set; }
    }
}
