using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_DoV_V._1 {
    public class Abillity {
        public string Name, Description;
        public float MinDMG, MaxDMG;
        public Abillity(string name, string description, float minDMG, float maxDMG) {
            Name = name;
            Description = description;
            MinDMG = minDMG;
            MaxDMG = maxDMG;
        }
    }
}
