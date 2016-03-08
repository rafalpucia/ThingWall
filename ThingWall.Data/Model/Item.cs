using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingWall.Data.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual User Owner { get; set; }
    }
}
