using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SB_Admin.Entities
{
    public class RecoveryPassword
    {
        public string token { get; set; }
        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        public string Password2 { get; set; }


        [EmailAddress]
        [Required]
        public string Email { get; set; }

    }
}