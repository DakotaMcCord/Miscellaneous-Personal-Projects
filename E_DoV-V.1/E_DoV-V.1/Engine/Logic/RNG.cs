using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_DoV_V._1 {
    public class RNG {
        static Random RandomNumber = new Random();
        public static int NumberBetween(int min, int max) {
            return RandomNumber.Next(min, max + 1);
        }
    }
}
