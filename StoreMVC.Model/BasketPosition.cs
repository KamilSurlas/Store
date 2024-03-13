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
    public class BasketPosition : IEntityTypeConfiguration<BasketPosition>
    {
        [Key]
        public int BasketPositionId { get; set; }
        [Required]
        public int Amount { get; set; }
        [ForeignKey(nameof(ProductId))]
        [Required]
        public int ProductId{ get; set; }
        [Required]
        public virtual Product? Product{ get; set; }
        [ForeignKey(nameof(UserId))]
        [Required]
        public int UserId { get; set; }
        [Required]
        public virtual User? User { get; set; }

        public void Configure(EntityTypeBuilder<BasketPosition> builder)
        {
            builder.HasOne(b => b.Product).WithMany(p => p.BasketPositions).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.User).WithMany(u => u.UserBasketPositions).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
