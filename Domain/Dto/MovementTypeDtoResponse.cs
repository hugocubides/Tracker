using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Constant;
using TrackerDomain.Models;

namespace TrackerDomain.Dto
{
    public class MovementTypeDtoResponse
    {
        public int Id { get; set; }
        public string MovementTypeName { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } =string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }= DateTime.Now;
    }
}
