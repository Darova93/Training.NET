using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class ItemTags
    {
        public int ItemId { get; set; }
        public int TagId { get; set; }

        public ItemTags(int itemid, int tagid)
        {
            ItemId = itemid;
            TagId = tagid;
        }

    }
}   
