using StoreMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL.Dto
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public virtual IEnumerable<OrderPositionResponseDto> OrderPositions { get; set; }
    }
}
