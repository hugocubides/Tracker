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
    public class BookDtoRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(16, ErrorMessage = Messages.MaxLength + "16")]
        public string BookName { get; set; } = string.Empty;
        [Required(ErrorMessage = Messages.Required)]
        [MaxLength(450, ErrorMessage = Messages.MaxLength + "450")]
        public string Owner { get; set; } = string.Empty;

        [Range(-10000000, 10000000, ErrorMessage = Messages.Range + "-10.000.000 y 10.000.000")]
        [Required(ErrorMessage = Messages.Required)]
        public decimal Balance { get; set; }
        [Required(ErrorMessage = Messages.Required)]
        public int StatusId { get; set; }

    }
}
