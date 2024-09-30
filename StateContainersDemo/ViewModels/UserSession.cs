using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateContainersDemo.Models
{
    public class UserSession
    {
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
    }
}
