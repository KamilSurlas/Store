using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreMVC.Model
{
    public class User 
    {
        [Key]
        public int UserId{ get; set; }
        [MaxLength(50)]
        public required string Login { get; set; }
        public required string Password { get; set; }
        public bool IsActive { get; set; }
        public Enums.Type Type { get; set; }

        public virtual IEnumerable<Order>? UserOrders { get; set; }
        public virtual IEnumerable<BasketPosition>? UserBasketPositions { get; set; }

      
    }
}