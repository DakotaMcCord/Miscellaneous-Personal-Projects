using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_DoV_V._1 {
    public class Creature : Entity {
        public float MaxHp, CurrentHP;
        public int Level;
        public Abillity abillity1, abillity2;
        public int CoolDown1 = 0, CoolDown2 = 0;
        public Creature(string id, string name, string description, Image myImage, float maxHp, float currentHP, int level, Abillity a1, Abillity a2) : base(id, name, description, myImage) {
            MaxHp = maxHp;
            CurrentHP = currentHP;
            Level = level;

            abillity1 = a1;
            abillity2 = a2;
        }
        public virtual void Abillity1(TextBox CombatLog, Creature Aponent) {

        }
        public virtual void Abillity2(TextBox CombatLog, Creature Aponent) {

        }

        public static Creature GetCreatureByID(string id) {
            for (int i = 0; i < GameData.MasterCreatureList.Count; i++) {
                if (GameData.MasterCreatureList[i].ID == id) {
                    return GameData.MasterCreatureList[i];
                }
            }
            return null;
        }
    }
}
