using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.Model
{
    public class Product 
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Image { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<BasketPosition>? BasketPositions { get; set; }  
        public virtual IEnumerable<OrderPosition>? OrderPositions { get; set; }
    }
}
