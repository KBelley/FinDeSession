using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinDeSession.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage="Please enter a username")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Please enter your password")]
        public string Password { get; set; }
    }
}