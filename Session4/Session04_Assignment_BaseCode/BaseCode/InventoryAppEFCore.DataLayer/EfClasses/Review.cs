using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [MaxLength(50)]
        [Required]
        public string VoterName { get; set; }

        public string Comment { get; set; }
        public int NumStars { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
    }
}
