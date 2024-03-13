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
    public class Order : IEntityTypeConfiguration<Order>
    {
        [Key]
        public int OrderId{ get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey(nameof(UserId))]
        [Required]
        public int UserId{ get; set; }
        [Required]
        public virtual User? User { get; set; }
        [Required]
        public virtual IEnumerable<OrderPosition>? OrderPositions { get; set; }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.User).WithMany(u => u.UserOrders).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(o => o.OrderPositions).WithOne(o => o.Order).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
