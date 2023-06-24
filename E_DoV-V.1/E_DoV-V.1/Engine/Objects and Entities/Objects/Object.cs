using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_DoV_V._1 {
    public class Object : BaseOE {
        public string NamePlural;
        public float Weight, Value;
        public Object(string id, string name, string description, Image myImage, string namePlural, float weight, float value) : base(id, name, description, myImage) {
            NamePlural = namePlural;
            Weight = weight;
            Value = value;
        }
        public static Object GetObjectByName(string Name) {
            for (int I = 0; I < GameData.MasterItemList.Count; I++) {
                if (GameData.MasterItemList[I].Name == Name) {
                    return GameData.MasterItemList[I];
                }
            }
            return null;
        }
    }
}
