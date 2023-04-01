using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(2000)]
        public string Name { get; set; }
    }
}