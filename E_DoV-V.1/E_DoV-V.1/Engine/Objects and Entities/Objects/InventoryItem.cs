using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_DoV_V._1 {
    public class InventoryItem {
        public Object Item;
        public int Count;
        public InventoryItem(Object item, int count) {
            Item = item;
            Count = count;
        }
    }
}
