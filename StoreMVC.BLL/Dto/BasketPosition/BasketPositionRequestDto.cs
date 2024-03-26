using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL.Dto
{
    public class BasketPositionRequestDto
    {
        public required int ProductId { get; set; }
        public required int UserId { get; set; }
        public required int Amount { get; set; }
    }
}
