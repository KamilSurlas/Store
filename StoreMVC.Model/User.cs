using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreMVC.Model
{
    public class User 
    {
        [Key]
        public int UserId{ get; set; }
        [Required]
        public string? Login { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public Enums.Type Type { get; set; }

        public virtual IEnumerable<Order>? UserOrders { get; set; }
        public virtual IEnumerable<BasketPosition>? UserBasketPositions { get; set; }

      
    }
}