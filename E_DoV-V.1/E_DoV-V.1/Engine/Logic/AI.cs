using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_DoV_V._1 {
    public class AI {
        public static void UseAction(TextBox CombatLog, PictureBox Background, Label ANameLBL, Label ALevelLBL, ProgressBar AHPBar, PictureBox AIMG, Label ENameLBL, Label ELevelLBL, ProgressBar EHPBar, PictureBox EIMG) {
            Thread.Sleep(200);
            if (RNG.NumberBetween(1,100) < 20 && CombatHandeler.SelectedECreature.CurrentHP < 30) {
                CombatHandeler.SelectedECreature.Abillity2(CombatLog, CombatHandeler.SelectedACreature);
            }
            else {
                CombatHandeler.SelectedECreature.Abillity1(CombatLog, CombatHandeler.SelectedACreature);
            }

            CombatHandeler.AdjustUI(Background,
               ANameLBL, ALevelLBL, AHPBar, AIMG,
               ENameLBL, ELevelLBL, EHPBar, EIMG);
        }
    }
}
