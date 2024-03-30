using TrackerDomain.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerDomain.Models
{
    public class Status : Audit
    {
        public Status() { }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(8, ErrorMessage = Messages.MaxLength + "8")]
        public string StatusName { get; set; } = string.Empty;

    }
}
