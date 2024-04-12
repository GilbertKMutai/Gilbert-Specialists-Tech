using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnusApp.Shared
{
    public class Client
    {
        [Required (ErrorMessage = "The field Name is required")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Please enter an Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter a message")]
        public string Message { get; set; }
    }
}
