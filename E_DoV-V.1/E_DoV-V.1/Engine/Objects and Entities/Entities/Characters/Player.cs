using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_DoV_V._1 {
    public class Player : Character {
        public Player(string id, string name, string description, Image myImage, Creature spawn1, Creature spawn2, Creature spawn3, float currentCarryWeight, float maxCarryWeight) : base(id, name, description, myImage, spawn1, spawn2, spawn3, currentCarryWeight, maxCarryWeight) {

        }
    }
}
