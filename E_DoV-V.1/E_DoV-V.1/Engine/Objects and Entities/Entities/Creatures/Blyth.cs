using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_DoV_V._1 {
    public class Blyth : Creature {
        public Blyth(string id, string name, string  description, Image myImage, float maxHp, float currentHP, int level, Abillity a1, Abillity a2) : base (id, name, description, myImage, maxHp, currentHP, level, a1, a2) {

        }
        public override void Abillity1(TextBox CombatLog, Creature Aponent) {
            CombatLog.Text += $"{abillity1.Description}{Environment.NewLine}";

            int DMG = RNG.NumberBetween((int)abillity1.MinDMG, (int)abillity1.MaxDMG);
            Aponent.CurrentHP -= DMG;

            CombatLog.Text += $"{this.Name} Does x{DMG} Dmg to {Aponent.Name}{Environment.NewLine}{Environment.NewLine}";
            base.Abillity1(CombatLog, Aponent);
        } // Eye Beem
        public override void Abillity2(TextBox CombatLog, Creature Aponent) {
            CombatLog.Text += $"{abillity2.Description}{Environment.NewLine}";

            int HealAmmt = RNG.NumberBetween((int)abillity2.MaxDMG, (int)abillity2.MinDMG);
            this.CurrentHP -= HealAmmt;

            if (CurrentHP > MaxHp) {
                CurrentHP = MaxHp;
                CombatLog.Text += $"{this.Name} Heals To Full HP{Environment.NewLine}{Environment.NewLine}";
            }
            else {
                CombatLog.Text += $"{this.Name} Heals x{HealAmmt * -1} Points{Environment.NewLine}{Environment.NewLine}";
            }

            CoolDown2 = 2;
            base.Abillity2(CombatLog, Aponent);
        } // Heal
    }
}
