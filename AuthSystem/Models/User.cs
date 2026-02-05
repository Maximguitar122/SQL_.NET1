using System;
using System.Collections.Generic;
using System.Text;

namespace AuthSystem.Models
{
    public class User
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
