﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer
{
    public class ClientView
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
