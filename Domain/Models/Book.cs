using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Constant;

namespace TrackerDomain.Models
{
    public class Book : Audit
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(16, ErrorMessage = Messages.MaxLength + "16")]
        public string BookName { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(450, ErrorMessage = Messages.MaxLength + "450")]
        public string Owner { get; set; }
        [Range(-10000000,10000000,ErrorMessage = Messages.Range + "-10.000.000 y 10.000.000")]
        [Required(ErrorMessage = Messages.Required)]
        public decimal Balance { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        public int StatusId { get; set; }

        //public virtual ICollection<Movement> Movements { get; set; }

    }
}
