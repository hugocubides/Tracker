using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Constant;
using TrackerDomain.Models;

namespace TrackerDomain.Dto
{
    public class MovementDtoRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date")]
        public DateOnly MovementDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required(ErrorMessage = Messages.Required)]    
        [MaxLength(32, ErrorMessage = Messages.MaxLength + "32")]
        [MinLength(4, ErrorMessage = Messages.MinLength + "4")]
        public string Entity { get; set; }

        [Required(ErrorMessage = Messages.Required)]
        [DisplayName("Movement Type")]
        public int MovementTypeId { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(32, ErrorMessage = Messages.MaxLength + "32")]
        [MinLength(4, ErrorMessage = Messages.MinLength + "4")]
        public string Detail { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [DisplayName("Book Source")]
        public int SourceBookId { get; set; }
        [DisplayName("Book Destination")]
        public int? DestinationBookId { get; set; }
        [DisplayName("Other Book")]
        public int? DestinationOtherBookId { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [Range(0, 10000000, ErrorMessage = Messages.Range + " 0, 10.000.000")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [Range(0, 10000000, ErrorMessage = Messages.Range + " 0, 10.000.000")]
        public decimal Balance { get; set; }
        public int? ParentMovementId { get; set; }

        [Required(ErrorMessage = Messages.Required)]
        [DisplayName("Is Shared")]
        public bool IsShared { get; set; } = false;
        public int? PayMovementId { get; set; }

        [Required(ErrorMessage = Messages.Required)]
        public int StatusId { get; set; }
    }
}
