using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Constant;

namespace TrackerDomain.Dto
{
    public class StatusDtoRequest
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(8, ErrorMessage = Messages.MaxLength + "8")]
        public string StatusName { get; set; } = string.Empty;

    }
}
