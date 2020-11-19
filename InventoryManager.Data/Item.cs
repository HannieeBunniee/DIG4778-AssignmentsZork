using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Data
{
    public class Item
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }
    }
}
