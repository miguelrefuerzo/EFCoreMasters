﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime DateOrderedUtc { get; private set; }

        //relationships
        public ICollection<LineItem> LineItems { get; set; }

        public OrderStatus Status { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
    }
}
