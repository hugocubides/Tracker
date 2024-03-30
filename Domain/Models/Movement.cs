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
    public class Movement : Audit
    {
        [Required(ErrorMessage = Messages.Required)]
        public DateOnly MovementDate { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(32,ErrorMessage = Messages.MaxLength + "32" )]
        [MinLength(4, ErrorMessage = Messages.MinLength + "4")]
        public string  Entity { get; set; } = string.Empty;
        [ForeignKey("MovementTypeId")]
        public virtual MovementType MovementType { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        public int MovementTypeId { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(32, ErrorMessage = Messages.MaxLength + "32")]
        [MinLength(4, ErrorMessage = Messages.MinLength + "4")]
        public string Detail { get; set; } = string.Empty;
        [ForeignKey("SourceBookId")]
        public int SourceBookId { get; set; }
        public virtual Book SourceBook { get; set; }

        //Se utiliza únicamente para almacenar cuentas propias       
        [ForeignKey("DestinationBookId")]
        public int? DestinationBookId { get; set; }
        public virtual Book DestinationBook { get; set; }
        // Se utiliza únicamente para almacenar cuentas de otros: terceros
        [ForeignKey("DestinationOtherBookId")]
        public int? DestinationOtherBookId { get; set; }
        public virtual Book DestinationOtherBook { get; set; }

        [Required(ErrorMessage = Messages.Required)]
        [Range(0,10000000, ErrorMessage = Messages.Range + " 0, 10.000.000")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [Range(0, 10000000, ErrorMessage = Messages.Range + " 0, 10.000.000")]
        public decimal Balance { get; set; }

        [ForeignKey("ParentMovementId")]
        public virtual Movement ParentMovement { get; set; }
        public int? ParentMovementId { get; set; }

        [Required(ErrorMessage = Messages.Required)]
        public bool IsShared { get; set; }
        [ForeignKey("PayMovementId")]
        public virtual Movement PayMovement { get; set; }
        public int? PayMovementId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        public int StatusId { get; set; }


    }
}
