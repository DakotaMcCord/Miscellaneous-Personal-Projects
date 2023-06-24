using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_DoV_V._1 {
    public class Character : Entity {
        public Creature Spawn1, Spawn2, Spawn3;
        public List<InventoryItem> MyInventory;
        public float CurrentCarryWeight, MaxCarryWeight;
        public Character(string id, string name, string description, Image myImage, Creature spawn1, Creature spawn2, Creature spawn3, float currentCarryWeight, float maxCarryWeight) : base(id, name, description, myImage) {
            Spawn1 = spawn1;
            Spawn2 = spawn2;
            Spawn3 = spawn3;

            CurrentCarryWeight = currentCarryWeight;
            MaxCarryWeight = maxCarryWeight;

            MyInventory = new List<InventoryItem>();
        }
        public static float GetCarryWeight(List<InventoryItem> Inventory) {
            float Num = 0;
            for (int i = 0; i < Inventory.Count; i++) {
                Num += (Inventory[i].Item.Weight * Inventory[i].Count);
            }
            return Num;
        }
    }
}
