using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerDomain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(64)]
        public string FirsName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
    }
}
