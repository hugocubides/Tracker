using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Constant;

namespace TrackerDomain.Models
{
    public class MovementType : Audit
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(16, ErrorMessage = Messages.MaxLength + "16")]
        public string MovementTypeName { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        public int StatusId { get; set; }
        //public virtual ICollection<Movement> Movements { get; set; }
    }
}
