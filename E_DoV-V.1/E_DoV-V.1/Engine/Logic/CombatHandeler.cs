using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_DoV_V._1 {
    public class CombatHandeler {
        public static List<Creature>
            AlliedCreatures = new List<Creature>(),
            EnemyCreatures = new List<Creature>();
        public static Creature SelectedACreature = null, SelectedECreature = null;
        public static bool Load = false, Break = false, Win = false, Lose = false, Flee = false;

        public static void LoadCombat(TextBox CombatLog, PictureBox Background, Label ANameLBL, Label ALevelLBL, ProgressBar AHPBar, PictureBox AIMG, Label ENameLBL, Label ELevelLBL, ProgressBar EHPBar, PictureBox EIMG) {
            for (int i = 0; i < GameData.ActionButtons.Count; i++) {
                GameData.ActionButtons[i].Enabled = false;
            }
            for (int i = 0; i < GameData.CombatButtons.Count; i++) {
                GameData.CombatButtons[i].Enabled = true;
            }

            AlliedCreatures.Clear();
            EnemyCreatures.Clear();

            SelectedACreature = null;
            SelectedECreature = null;

            Win = false;
            Lose = false;
            Flee = false;

            CombatLog.Text = string.Empty;
            ANameLBL.Text = "???";
            ALevelLBL.Text = "???";
            AHPBar.Value = 0;
            AIMG.Image = null;

            for (int i = 0; i < GameData.CombatButtons.Count; i++) {
                GameData.CombatButtons[i].Visible = false;
                GameData.CombatButtons[i].Enabled = false;
            }

            LoadPlayerSpawns();
            GetEncounter();

            CombatLog.Text += $"You Are Ambushed By x{EnemyCreatures.Count} Creature(s):{Environment.NewLine}";
            for (int i = 0; i < EnemyCreatures.Count; i++) {
                CombatLog.Text += $" - {EnemyCreatures[i].Name}{Environment.NewLine}";
            }
            CombatLog.Text += Environment.NewLine;

            GetEnemyCreature();
            AdjustUI(Background, ANameLBL, ALevelLBL, AHPBar, AIMG, ENameLBL, ELevelLBL, EHPBar, EIMG);
        }

        public static void GetEncounter() {
            LoadEncounter();

            Load = true;
        }
        public static void LoadDual() {

        }
        public static void LoadEncounter() {
            int Count = RNG.NumberBetween(1, (int)GameData.CurrentScene.RType);
            for (int i = 0; i < Count; i++) {
                Creature creature = GameData.MasterCreatureList[RNG.NumberBetween(0, GameData.MasterCreatureList.Count - 1)];
                EnemyCreatures.Add(new Blyth(creature.ID, "Roaving " + creature.Name, creature.Description, creature.MyImage, creature.MaxHp, creature.CurrentHP, creature.Level, creature.abillity1, creature.abillity2));
            }
        }
        public static void LoadPlayerSpawns() {
            if (GameData.player.Spawn1 != null) {
                AlliedCreatures.Add(GameData.player.Spawn1);
            }
            if (GameData.player.Spawn2 != null) {
                AlliedCreatures.Add(GameData.player.Spawn2);
            }
            if (GameData.player.Spawn3 != null) {
                AlliedCreatures.Add(GameData.player.Spawn3);
            }
        }

        public static void AdjustUI(PictureBox Background, Label ANameLBL, Label ALevelLBL, ProgressBar AHPBar, PictureBox AIMG, Label ENameLBL, Label ELevelLBL, ProgressBar EHPBar, PictureBox EIMG) {
            Background.Image = GameData.GetIMGByTag("Err");

            Creature Check = null;
            if (Check != SelectedACreature) {
                Check = SelectedACreature;
                for (int i = 0; i < GameData.CombatButtons.Count; i++) {
                    GameData.CombatButtons[i].Visible = false;
                    GameData.CombatButtons[i].Enabled = false;
                }
            }

            CheckDead();

            for (int i = 0; i < GameData.VSRelay.Count; i++) {
                GameData.VSRelay[i].Visible = false;
            }
            for (int i = 0; i < AlliedCreatures.Count; i++) {
                if (AlliedCreatures[i].CurrentHP > 0) {
                    GameData.VSRelay[i].Image = AlliedCreatures[i].MyImage;
                }
                else {
                    GameData.VSRelay[i].Image = GameData.GetIMGByTag("DG");
                }
                GameData.VSRelay[i].Visible = true;
            }
            for (int i = 0; i < EnemyCreatures.Count; i++) {
                if (EnemyCreatures[i].CurrentHP > 0) {
                    GameData.VSRelay[i + 3].Image = GameData.GetIMGByTag(EnemyCreatures[i].MyImage.Tag.ToString().Split('*')[0]);
                }
                else {
                    GameData.VSRelay[i + 3].Image = GameData.GetIMGByTag("DG");
                }
                GameData.VSRelay[i + 3].Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                GameData.VSRelay[i + 3].Visible = true;
            }

            if (SelectedACreature != null) {
                ANameLBL.Text = SelectedACreature.Name;
                ALevelLBL.Text = "Level: " + SelectedACreature.Level.ToString();
                AIMG.Image = SelectedACreature.MyImage;
                if (Load == false) {
                    while (AHPBar.Value > (int)SelectedACreature.CurrentHP * 100 / (int)SelectedACreature.MaxHp) {
                        AHPBar.Value -= 1;
                        Thread.Sleep(30);
                    }
                    while (AHPBar.Value < (int)SelectedACreature.CurrentHP * 100 / (int)SelectedACreature.MaxHp) {
                        AHPBar.Value += 1;
                        Thread.Sleep(30);
                    }
                }
                AHPBar.Value = (int)SelectedACreature.CurrentHP * 100 / (int)SelectedACreature.MaxHp;

                if (SelectedACreature.abillity1 != null) {
                    GameData.CombatButtons[0].Visible = true;
                    GameData.CombatButtons[0].Enabled= true;
                    GameData.CombatButtons[0].Text = SelectedACreature.abillity1.Name;
                }
                if (SelectedACreature.abillity2 != null) {
                    GameData.CombatButtons[1].Visible = true;
                    GameData.CombatButtons[1].Enabled = true;
                    GameData.CombatButtons[1].Text = SelectedACreature.abillity2.Name;
                }

                GameData.CombatButtons[8].Visible = true;
                GameData.CombatButtons[8].Enabled = true;
            }
            if (SelectedECreature != null) {
                ENameLBL.Text = SelectedECreature.Name;
                ELevelLBL.Text = "Level: " + SelectedECreature.Level.ToString();
                EIMG.Image = GameData.GetIMGByTag(SelectedECreature.MyImage.Tag.ToString().Split('*')[0]);
                EIMG.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                if (Load == false && EHPBar.Value != 0) {
                    while (EHPBar.Value > (int)SelectedECreature.CurrentHP * 100 / (int)SelectedECreature.MaxHp) {
                        EHPBar.Value -= 1;
                        Thread.Sleep(30);
                    }
                    while (EHPBar.Value < (int)SelectedECreature.CurrentHP * 100 / (int)SelectedECreature.MaxHp) {
                        EHPBar.Value += 1;
                        Thread.Sleep(30);
                    }
                }
                EHPBar.Value = (int)SelectedECreature.CurrentHP * 100 / (int)SelectedECreature.MaxHp;
            }

            if (Win == false && Lose == false) {
                CheckWinLose();
                if (Win == false && Lose == false) {
                    GetEnemyCreature();
                    if (Break == true) {
                        if (SelectedECreature != null) {
                            ENameLBL.Text = SelectedECreature.Name;
                            ELevelLBL.Text = "Level: " + SelectedECreature.Level.ToString();
                            EIMG.Image = GameData.GetIMGByTag(SelectedECreature.MyImage.Tag.ToString().Split('*')[0]);
                            EIMG.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            if (Load == false && EHPBar.Value != 0) {
                                while (EHPBar.Value > (int)SelectedECreature.CurrentHP * 100 / (int)SelectedECreature.MaxHp) {
                                    EHPBar.Value -= 1;
                                    Thread.Sleep(30);
                                }
                                while (EHPBar.Value < (int)SelectedECreature.CurrentHP * 100 / (int)SelectedECreature.MaxHp) {
                                    EHPBar.Value += 1;
                                    Thread.Sleep(30);
                                }
                            }
                            EHPBar.Value = (int)SelectedECreature.CurrentHP * 100 / (int)SelectedECreature.MaxHp;
                        }
                    }
                }
            }

            CombatHandeler.Load = false;
        }

        public static void GetEnemyCreature() {
            if (SelectedECreature != null) {
                while (SelectedECreature.CurrentHP == 0) {
                    SelectedECreature = EnemyCreatures[RNG.NumberBetween(0, EnemyCreatures.Count - 1)];
                    Break = true;
                }
            }
            else {
                SelectedECreature = EnemyCreatures[RNG.NumberBetween(0, EnemyCreatures.Count - 1)];
            }
        }
        public static void CheckDead() {
            if (SelectedACreature != null && SelectedACreature.CurrentHP < 0) {
                SelectedACreature.CurrentHP = 0;
            }
            if (SelectedECreature != null && SelectedECreature.CurrentHP < 0) {
                SelectedECreature.CurrentHP = 0;
            }
        }
        public static void CheckWinLose() {
            bool AAlive = false, EAlive = false;

            for (int i = 0; i < AlliedCreatures.Count; i++) {
                if (AlliedCreatures[i].CurrentHP > 0) {
                    AAlive = true;
                }
            }
            for (int i = 0; i < EnemyCreatures.Count; i++) {
                if (EnemyCreatures[i].CurrentHP > 0) {
                    EAlive = true;
                }
            }

            if (AAlive == false) {
                MessageBox.Show("You Lose");
                SelectedACreature = null;
                Break = true;
                Lose = true;
            } // Lose Condition
            if (EAlive == false) {
                MessageBox.Show("You Win");
                SelectedECreature = null;
                Break = true;
                Win = true;
            } // Win Condition
        }
        public static void GetEnemyTurn(TextBox CombatLog, PictureBox Background, Label ANameLBL, Label ALevelLBL, ProgressBar AHPBar, PictureBox AIMG, Label ENameLBL, Label ELevelLBL, ProgressBar EHPBar, PictureBox EIMG) {
            if (Break == false && SelectedECreature.CurrentHP > 0) {
                AI.UseAction(CombatLog, Background, ANameLBL, ALevelLBL, AHPBar, AIMG, ENameLBL, ELevelLBL, EHPBar, EIMG);
            }
            AdjustUI(Background, ANameLBL, ALevelLBL, AHPBar, AIMG, ENameLBL, ELevelLBL, EHPBar, EIMG);
            Break = false;
        }
        public static void ReduceCoolDown() {
            for (int i = 0; i < AlliedCreatures.Count; i++) {
                if (AlliedCreatures[i].CoolDown1 > 0) {
                    AlliedCreatures[i].CoolDown1 -= 1;
                }
                if (AlliedCreatures[i].CoolDown2 > 0) {
                    AlliedCreatures[i].CoolDown2 -= 1;
                }
            }
            for (int i = 0; i < EnemyCreatures.Count; i++) {
                if (EnemyCreatures[i].CoolDown1 > 0) {
                    EnemyCreatures[i].CoolDown1 -= 1;
                }
                if (EnemyCreatures[i].CoolDown2 > 0) {
                    EnemyCreatures[i].CoolDown2 -= 1;
                }
            }
        }
    }
}
