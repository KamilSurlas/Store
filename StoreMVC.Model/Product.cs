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
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [ForeignKey(nameof(BasketPositionId))]
        public int BasketPositionId { get; set; }
        public virtual IEnumerable<BasketPosition>? BasketPositions { get; set; }

        
    }
}
