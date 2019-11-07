using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime LoginDate { get; set; }
        public string LoginDateFormatted { get; set; }
        public int UserCount { get; set; }
    }
}