using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL.Dto
{
    public class ProductRequestDto
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required string Image { get; set; }
        public required bool IsActive { get; set; }
    }
}
