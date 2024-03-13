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
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? Amount{ get; set; }


        [ForeignKey(nameof(OrderId))] 
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder.HasOne(o => o.Order).WithMany(o => o.OrderPositions).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
