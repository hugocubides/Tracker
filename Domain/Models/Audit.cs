using TrackerDomain.Constant;
using System.ComponentModel.DataAnnotations;
using System.CodeDom;

namespace TrackerDomain.Models
{
    public abstract class Audit
    {
        protected Audit(){}

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required(ErrorMessage = Messages.Required)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(8, ErrorMessage = Messages.MaxLength + "8")]
        public string CreatedBy { get; set; }
        [MaxLength(8, ErrorMessage = Messages.MaxLength + "8")]
        [Required(ErrorMessage = Messages.Required)]
        public string UpdatedBy { get; set; }

    }
}
