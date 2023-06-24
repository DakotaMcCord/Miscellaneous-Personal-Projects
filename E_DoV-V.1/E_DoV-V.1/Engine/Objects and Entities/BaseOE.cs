using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_DoV_V._1 {
    public class BaseOE {
        public string ID, Name, Description;
        public Image MyImage;

        public BaseOE(string id, string name, string description, Image myImage = null) {
            ID = id;
            Name = name;
            Description = description;
            MyImage = myImage;
        }
    }
}
