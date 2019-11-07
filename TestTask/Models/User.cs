using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LoginDate { get; set; }
    }
}