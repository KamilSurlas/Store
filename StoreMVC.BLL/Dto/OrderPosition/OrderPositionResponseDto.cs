using StoreMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL.Dto
{
    public class OrderPositionResponseDto
    {
        public decimal Price { get; set; }
        public int Amount { get; set; }           
        public ProductResponseDto Product { get; set; }
    }
}
