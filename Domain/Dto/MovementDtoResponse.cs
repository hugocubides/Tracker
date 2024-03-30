using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Constant;
using TrackerDomain.Models;

namespace TrackerDomain.Dto
{
    public class MovementDtoResponse
    {
        public int Id { get; set; }
        [DisplayName("Date")]
        public DateOnly MovementDate { get; set; }
        public string Entity { get; set; }
        [DisplayName("Movement Type")]
        public virtual MovementType MovementType { get; set; }
        public int MovementTypeId { get; set; }
        public string Detail { get; set; }
        [DisplayName("Source Book")]
        public int SourceBookId { get; set; }
        public virtual Book SourceBook { get; set; }
        [DisplayName("Destination Book")]
        public int? DestinationBookId { get; set; }
        public virtual Book DestinationBook { get; set; }
        [DisplayName("Other Book")]
        public int? DestinationOtherBookId { get; set; }
        public virtual Book DestinationOtherBook { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
        public virtual Movement ParentMovement { get; set; }
        public int? ParentMovementId { get; set; }
        public bool IsShared { get; set; }
        public virtual Movement PayMovement { get; set; }
        public int? PayMovementId { get; set; }
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
