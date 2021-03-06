﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingWall.Data.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual User Owner { get; set; }
    }
}
