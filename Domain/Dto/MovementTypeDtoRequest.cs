using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Constant;

namespace TrackerDomain.Dto
{
    public class MovementTypeDtoRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(16, ErrorMessage = Messages.MaxLength + "16")]
        public string MovementTypeName { get; set; }
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }


    }
}
