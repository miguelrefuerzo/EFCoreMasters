using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Product
    {
        private string _backingField;

        [Key]
        public int ProductId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name 
        { 
            get { return _backingField; } 
            set { _backingField = value; }
        } //backing field

        //relationships---
        public PriceOffer Promotion { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public ICollection<Supplier> SuppliersLink { get; set; }

        public bool IsDeleted { get; set; }

        [NotMapped]
        public ExcludeClass ExcludeClass { get; set; }
    }
}
