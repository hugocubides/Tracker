using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerDomain.Dto
{
    public class MovementDtoList
    {
        public List<MovementDtoResponse>? listIncomeMovements { get; set; } 
        public List<MovementDtoResponse>? listExpenseMovements { get; set; }
        public List<MovementDtoResponse>? listTransferMovements { get; set; }
        public List<BookDtoResponse>? listBook {  get; set; } 
    }
}
