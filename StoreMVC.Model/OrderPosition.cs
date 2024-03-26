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
    public class OrderPosition : IEntityTypeConfiguration<OrderPosition>
    {
        [Key]
        public int OrderPositionId { get; set; }
        
        public decimal Price { get; set; }
       
        public int Amount{ get; set; }


        [ForeignKey(nameof(OrderId))] 
        public int OrderId { get; set; }
        public required virtual Order Order { get; set; }


        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public required virtual Product Product { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder.HasOne(o => o.Order).WithMany(o => o.OrderPositions).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(p => p.OrderPositions).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
