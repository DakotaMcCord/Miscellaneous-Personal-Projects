using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_DoV_V._1 {
    public partial class GameWindow : Form {
        public GameWindow() {
            InitializeComponent();
        }
        private void GameWindow_Load(object sender, EventArgs e) {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            CenterToScreen();

            this.Text = $"Egragoi: Dawn of Venandi - Main Menu";
            StartButton.Text = "Start";
            LoadButton.Text = "Load";
            SaveButton.Text = "Save";
            OptionsButton.Text = "Options";
            ExtrasButton.Text = "Extras";
            ExitButton.Text = "Exit";

            MNButton.Text = "North";
            MNEButton.Text = "NE";
            MEButton.Text = "East";
            MSEButton.Text = "SE";
            MSButton.Text = "South";
            MSWButton.Text = "SW";
            MWButton.Text = "West";
            MNWButton.Text = "NW";
            MUButton.Text = "Up";
            MDButton.Text = "Down";

            #region Add Nav Buttons
            GameData.NavB.Add(MNButton);
            GameData.NavB.Add(MNEButton);
            GameData.NavB.Add(MEButton);
            GameData.NavB.Add(MSEButton);
            GameData.NavB.Add(MSButton);
            GameData.NavB.Add(MSWButton);
            GameData.NavB.Add(MWButton);
            GameData.NavB.Add(MNWButton);
            GameData.NavB.Add(MUButton);
            GameData.NavB.Add(MDButton);
            #endregion
            #region Add Action Buttons
            GameData.ActionButtons.Add(A1Button);
            GameData.ActionButtons.Add(A2Button);
            GameData.ActionButtons.Add(A3Button);
            GameData.ActionButtons.Add(A4Button);
            GameData.ActionButtons.Add(A5Button);
            GameData.ActionButtons.Add(A6Button);
            GameData.ActionButtons.Add(A7Button);
            GameData.ActionButtons.Add(A8Button);
            GameData.ActionButtons.Add(A9Button);
            GameData.ActionButtons.Add(A10Button);
            GameData.ActionButtons.Add(A11Button);
            GameData.ActionButtons.Add(A12Button);
            GameData.ActionButtons.Add(A13Button);
            //GameData.ActionButtons.Add(A14Button);
            //GameData.ActionButtons.Add(A15Button);

            //A13Button.Visible = false;
            A14Button.Text = "Inventory";
            A15Button.Text = "Main Menu";
            #endregion
            #region Add Combat Buttons
            GameData.CombatButtons.Add(C1Button);
            GameData.CombatButtons.Add(C2Button);
            GameData.CombatButtons.Add(C3Button);
            GameData.CombatButtons.Add(C4Button);
            GameData.CombatButtons.Add(C5Button);
            GameData.CombatButtons.Add(C6Button);
            GameData.CombatButtons.Add(C7Button);
            //GameData.CombatButtons.Add(C8Button);
            //GameData.CombatButtons.Add(C9Button);
            GameData.CombatButtons.Add(C10Button);
            GameData.CombatButtons.Add(C11Button);
            GameData.CombatButtons.Add(C12Button);
            GameData.CombatButtons.Add(C13Button);
            //GameData.CombatButtons.Add(C14Button);

            C8Button.Text = "Use Item";
            C9Button.Text = "Select Spawn";
            C11Button.Text = "Flee";
            C14Button.Text = A15Button.Text;
            #endregion
            #region UI Adjustments
            Spawn1IMGBox.SizeMode = PictureBoxSizeMode.Zoom;
            Spawn2IMGBox.SizeMode = PictureBoxSizeMode.Zoom;
            Spawn3IMGBox.SizeMode = PictureBoxSizeMode.Zoom;

            ASpawn1IMGBox.SizeMode = PictureBoxSizeMode.Zoom;
            ESpawn1IMGBox.SizeMode = PictureBoxSizeMode.Zoom;

            Spawn1HPBar.Style = ProgressBarStyle.Continuous;
            Spawn1HPBar.ForeColor = Color.Green;
            Spawn2HPBar.Style = ProgressBarStyle.Continuous;
            Spawn2HPBar.ForeColor = Color.Green;
            Spawn3HPBar.Style = ProgressBarStyle.Continuous;
            Spawn3HPBar.ForeColor = Color.Green;

            ASpawn1HPBar.Style = ProgressBarStyle.Continuous;
            ASpawn1HPBar.ForeColor = Color.Green;
            ESpawn1HPBar.Style = ProgressBarStyle.Continuous;
            ESpawn1HPBar.ForeColor = Color.Green;

            AS1IMGBox.SizeMode = PictureBoxSizeMode.Zoom;
            AS2IMGBox.SizeMode = PictureBoxSizeMode.Zoom;
            AS3IMGBox.SizeMode = PictureBoxSizeMode.Zoom;
            ES1IMGBox.SizeMode = PictureBoxSizeMode.Zoom;
            ES2IMGBox.SizeMode = PictureBoxSizeMode.Zoom;
            ES3IMGBox.SizeMode = PictureBoxSizeMode.Zoom;

            GameData.VSRelay.Add(AS1IMGBox);
            GameData.VSRelay.Add(AS2IMGBox);
            GameData.VSRelay.Add(AS3IMGBox);
            GameData.VSRelay.Add(ES1IMGBox);
            GameData.VSRelay.Add(ES2IMGBox);
            GameData.VSRelay.Add(ES3IMGBox);

            NEWSBox.Image = GameData.GetIMGByTag("Err");
            UDBox.Image = GameData.GetIMGByTag("Err");
            #endregion
        }
        #region Action Buttons
        private void A1Button_Click(object sender, EventArgs e) {
            ActionLog.Text += $"{Environment.NewLine}You Examine Your Surroundings Further";
            ExamineAndTakeView ETDialog = new ExamineAndTakeView(GameData.CurrentScene);

            ETDialog.ShowDialog();
            GetScene();
        } // Take Item
        private void A2Button_Click(object sender, EventArgs e) {

        }
        private void A3Button_Click(object sender, EventArgs e) {

        }
        private void A4Button_Click(object sender, EventArgs e) {

        }
        private void A5Button_Click(object sender, EventArgs e) {

        }
        private void A6Button_Click(object sender, EventArgs e) {
            if (GameData.player.Spawn1 != null) {
                if (GameData.player.Spawn1.CurrentHP < GameData.player.Spawn1.MaxHp) {
                    GameData.player.Spawn1.CurrentHP = GameData.player.Spawn1.MaxHp;
                    ActionLog.Text += $"{Environment.NewLine}{GameData.player.Spawn1.Name} Heals to Max HP";
                    while (Spawn1HPBar.Value < (int)GameData.player.Spawn1.CurrentHP * 100 / (int)GameData.player.Spawn1.MaxHp) {
                        Spawn1HPBar.Value += 1;
                        Thread.Sleep(30);
                    }
                }
                else {
                    ActionLog.Text += $"{Environment.NewLine}{GameData.player.Spawn1.Name} is Already at Max HP";
                }
            }
            if (GameData.player.Spawn2 != null) {
                if (GameData.player.Spawn2.CurrentHP < GameData.player.Spawn2.MaxHp) {
                    GameData.player.Spawn2.CurrentHP = GameData.player.Spawn2.MaxHp;
                    ActionLog.Text += $"{Environment.NewLine}{GameData.player.Spawn2.Name} Heals to Max HP";
                    while (Spawn2HPBar.Value < (int)GameData.player.Spawn2.CurrentHP * 100 / (int)GameData.player.Spawn2.MaxHp) {
                        Spawn2HPBar.Value += 1;
                        Thread.Sleep(30);
                    }
                }
                else {
                    ActionLog.Text += $"{Environment.NewLine}{GameData.player.Spawn2.Name} is Already at Max HP";
                }
            }
            if (GameData.player.Spawn3 != null) {
                if (GameData.player.Spawn3.CurrentHP < GameData.player.Spawn3.MaxHp) {
                    GameData.player.Spawn3.CurrentHP = GameData.player.Spawn3.MaxHp;
                    ActionLog.Text += $"{Environment.NewLine}{GameData.player.Spawn3.Name} Heals to Max HP";
                    while (Spawn3HPBar.Value < (int)GameData.player.Spawn3.CurrentHP * 100 / (int)GameData.player.Spawn3.MaxHp) {
                        Spawn3HPBar.Value += 1;
                        Thread.Sleep(30);
                    }
                }
                else {
                    ActionLog.Text += $"{Environment.NewLine}{GameData.player.Spawn3.Name} is Already at Max HP";
                }
            }
            UpdateStats();
        } // Rest
        private void A7Button_Click(object sender, EventArgs e) {

        }
        private void A8Button_Click(object sender, EventArgs e) {

        }
        private void A9Button_Click(object sender, EventArgs e) {

        }
        private void A10Button_Click(object sender, EventArgs e) {

        }
        private void A11Button_Click(object sender, EventArgs e) {

        }
        private void A12Button_Click(object sender, EventArgs e) {

        }
        private void A13Button_Click(object sender, EventArgs e) {

        }
        private void A14Button_Click(object sender, EventArgs e) {
            ActionLog.Text += $"{Environment.NewLine}You Open Your Inventory";
            PlayerInventoryView PIDialog = new PlayerInventoryView(GameData.CurrentScene);

            PIDialog.ShowDialog();
            GetScene();
        } // Inventory
        private void A15Button_Click(object sender, EventArgs e) {
            this.Text = $"Egragoi: Dawn of Venandi - Main Menu";
            MainMenuPanel.Show();
        }// Main Menu
        #endregion
        #region Navigation Buttons
        private void MNButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.North) {
                    GameData.PlayerLocationID.Y -= GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go North";
                    return;
                }
            }
        } // Move North
        private void MNEButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.NorthEast) {
                    GameData.PlayerLocationID.X += GameData.CurrentScene.ExitList[i].Spd;
                    GameData.PlayerLocationID.Y -= GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go North-East";
                    return;
                }
            }
        } // Move North East
        private void MEButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.East) {
                    GameData.PlayerLocationID.X += GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go East";
                    return;
                }
            }
        } // Move East
        private void MSEButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.SouthEast) {
                    GameData.PlayerLocationID.X += GameData.CurrentScene.ExitList[i].Spd;
                    GameData.PlayerLocationID.Y += GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go South-East";
                    return;
                }
            }
        } // Move South East
        private void MSButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.South) {
                    GameData.PlayerLocationID.Y += GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go South";
                    return;
                }
            }
        } // Move South
        private void MSWButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.SouthWest) {
                    GameData.PlayerLocationID.X -= GameData.CurrentScene.ExitList[i].Spd;
                    GameData.PlayerLocationID.Y += GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go South-West";
                    return;
                }
            }
        } // Move South West
        private void MWButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.West) {
                    GameData.PlayerLocationID.X -= GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go West";
                    return;
                }
            }
        } // Move West
        private void MNWButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.NorthWest) {
                    GameData.PlayerLocationID.X -= GameData.CurrentScene.ExitList[i].Spd;
                    GameData.PlayerLocationID.Y -= GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go North-West";
                    return;
                }
            }
        } // Move North West
        private void MUButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.Up) {
                    GameData.PlayerLocationID.Z += GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go Up";
                    return;
                }
            }
        } // Move Up
        private void MDButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < GameData.CurrentScene.ExitList.Count; i++) {
                if (GameData.CurrentScene.ExitList[i].Direction == Scene.Directions.Down) {
                    GameData.PlayerLocationID.Z -= GameData.CurrentScene.ExitList[i].Spd;
                    GetScene();
                    ActionLog.Text += $"{Environment.NewLine}You go Down";
                    return;
                }
            }
        } // Move Down
        #endregion
        #region Main Menu Buttons
        private void StartButton_Click(object sender, EventArgs e) {
            if (StartButton.Text != "Back") {
                StartButton.Text = "Back";
            }
            MainMenuPanel.Hide();
            GetScene();
            UpdateStats();
        } // Start Game
        private void SaveButton_Click(object sender, EventArgs e) {

        }
        private void LoadButton_Click(object sender, EventArgs e) {

        }
        private void OptionsButton_Click(object sender, EventArgs e) {

        }
        private void ExtrasButton_Click(object sender, EventArgs e) {

        }
        private void ExitButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show($"Are You Sure You Want to Exit?{Environment.NewLine}" +
                $"Any Unsaved Progress Will Be Lost.", "Please Confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                this.Close();
            }
        } // Exit Game
        #endregion
        #region Combat Buttons
        private void C1Button_Click(object sender, EventArgs e) {
            if (CombatHandeler.SelectedACreature.CoolDown1 == 0) {
                CombatHandeler.SelectedACreature.Abillity1(CombatLog, CombatHandeler.SelectedECreature);
                DoTurn();
            }
            else {
                CombatLog.Text += $"You Can Not Do That for x{CombatHandeler.SelectedACreature.CoolDown1} More Turns{Environment.NewLine}{Environment.NewLine}";
            }
        } // Abillity 1
        private void C2Button_Click(object sender, EventArgs e) {
            if (CombatHandeler.SelectedACreature.CoolDown2 == 0) {
                CombatHandeler.SelectedACreature.Abillity2(CombatLog, CombatHandeler.SelectedECreature);
                DoTurn();
            }
            else {
                CombatLog.Text += $"You Can Not Do That for x{CombatHandeler.SelectedACreature.CoolDown2} More Turns{Environment.NewLine}{Environment.NewLine}";
            }
        }// Abillity 2
        private void C3Button_Click(object sender, EventArgs e) {

        }
        private void C4Button_Click(object sender, EventArgs e) {

        }
        private void C5Button_Click(object sender, EventArgs e) {

        }
        private void C6Button_Click(object sender, EventArgs e) {

        }
        private void C7Button_Click(object sender, EventArgs e) {

        }
        private void C8Button_Click(object sender, EventArgs e) {

        } // Use Item
        private void C9Button_Click(object sender, EventArgs e) {
            CombatHandeler.Load = true;
            CombatHandeler.SelectedACreature = GameData.player.Spawn1;
            CombatHandeler.AdjustUI(BKGImageBox,
               ASpawn1NameLBL, ASpawn1LevelLBL, ASpawn1HPBar, ASpawn1IMGBox,
               ESpawn1NameLBL, ESpawn1LevelLBL, ESpawn1HPBar, ESpawn1IMGBox);
        } // Select Pawn
        private void C10Button_Click(object sender, EventArgs e) {

        }
        private void C11Button_Click(object sender, EventArgs e) {
            if (MessageBox.Show($"Are You Sure You Want to Flee?", "Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                CombatHandeler.Flee = true;
                DoTurn();
            }
        } // Flee Combat
        private void C12Button_Click(object sender, EventArgs e) {

        }
        private void C13Button_Click(object sender, EventArgs e) {

        }
        //private void C14Button_Click(object sender, EventArgs e) {

        //}
        #endregion
        private void DoTurn() {
            CombatHandeler.AdjustUI(BKGImageBox,
               ASpawn1NameLBL, ASpawn1LevelLBL, ASpawn1HPBar, ASpawn1IMGBox,
               ESpawn1NameLBL, ESpawn1LevelLBL, ESpawn1HPBar, ESpawn1IMGBox);

            CombatHandeler.GetEnemyTurn(CombatLog, BKGImageBox,
               ASpawn1NameLBL, ASpawn1LevelLBL, ASpawn1HPBar, ASpawn1IMGBox,
               ESpawn1NameLBL, ESpawn1LevelLBL, ESpawn1HPBar, ESpawn1IMGBox);

            if (CombatHandeler.Win == true || CombatHandeler.Lose == true || CombatHandeler.Flee == true) {
                for (int i = 0; i < GameData.ActionButtons.Count; i++) {
                    GameData.ActionButtons[i].Enabled = true;
                }
                A14Button.Enabled = true;
                A15Button.Enabled = true;
                for (int i = 0; i < GameData.CombatButtons.Count; i++) {
                    GameData.CombatButtons[i].Enabled = false;
                }
                C8Button.Enabled = false;
                C9Button.Enabled = false;
                C11Button.Enabled = false;
                C14Button.Enabled = false;

                for (int i = 0; i < CombatHandeler.AlliedCreatures.Count; i++) {
                    CombatHandeler.AlliedCreatures[i].CoolDown1 = 0;
                    CombatHandeler.AlliedCreatures[i].CoolDown2 = 0;
                }

                if (CombatHandeler.Win == true) {
                    ActionLog.Text += $"{Environment.NewLine}You Were Victorious in Combat";
                }
                if (CombatHandeler.Lose == true) {
                    ActionLog.Text += $"{Environment.NewLine}You Were Defeated in Combat";
                }
                if (CombatHandeler.Flee == true) {
                    MessageBox.Show("You Flee The Encounter!", "Running Away.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActionLog.Text += $"{Environment.NewLine}You Ran Away from Combat";
                }
                CombatViewPanel.Hide();
                UpdateStats();
            }
            else {
                CombatHandeler.ReduceCoolDown();
            }
        }

        public static int CombatCoolDown = 0;
        public void GetScene() {
            GameData.CurrentScene = Scene.GetSceneByID(GameData.PlayerLocationID, GameData.TMap);
            Scene.SceneHandeler(GameData.CurrentScene, this, RoomBannerBox, RoomDescriptionBox, GameData.NavB, GameData.ActionButtons);

            if (CombatCoolDown > 0) {
                CombatCoolDown -= 1;
            }
            if ((GameData.player.Spawn1 != null && GameData.player.Spawn1.CurrentHP > 0) ||
                    (GameData.player.Spawn2 != null && GameData.player.Spawn2.CurrentHP > 0) ||
                        (GameData.player.Spawn3 != null && GameData.player.Spawn3.CurrentHP > 0)) {
                if (GameData.CurrentScene.RType != Scene.RoomType.Passive && RNG.NumberBetween(0, 100) < 10 && CombatCoolDown == 0) {


                    for (int i = 0; i < GameData.ActionButtons.Count; i++) {
                        GameData.ActionButtons[i].Enabled = false;
                    }
                    A14Button.Enabled = false;
                    A15Button.Enabled = false;
                    for (int i = 0; i < GameData.CombatButtons.Count; i++) {
                        GameData.CombatButtons[i].Enabled = true;
                    }
                    C8Button.Enabled = true;
                    C9Button.Enabled = true;
                    C11Button.Enabled = true;
                    C14Button.Enabled = true;


                    CombatCoolDown = 5;
                    CombatHandeler.LoadCombat(CombatLog, BKGImageBox,
                    ASpawn1NameLBL, ASpawn1LevelLBL, ASpawn1HPBar, ASpawn1IMGBox,
                    ESpawn1NameLBL, ESpawn1LevelLBL, ESpawn1HPBar, ESpawn1IMGBox);
                    CombatViewPanel.Show();
                }
            }
            UpdateStats();
        } // Get Scene && Update UI
        public void UpdateStats() {
            Spawn1Panel.Hide();
            Spawn2Panel.Hide();
            Spawn3Panel.Hide();

            if (GameData.player.Spawn1 != null) {
                Spawn1Panel.Show();

                Spawn1IMGBox.Image = GameData.player.Spawn1.MyImage;
                Spawn1NameLBL.Text = GameData.player.Spawn1.Name;
                Spawn1HPBar.Value = (int)GameData.player.Spawn1.CurrentHP * 100 / (int)GameData.player.Spawn1.MaxHp;
                Spawn1LevelLBL.Text = "Level: " + GameData.player.Spawn1.Level.ToString();
            }
            if (GameData.player.Spawn2 != null) {
                Spawn2Panel.Show();

                Spawn2IMGBox.Image = GameData.player.Spawn2.MyImage;
                Spawn2NameLBL.Text = GameData.player.Spawn2.Name;
                Spawn2HPBar.Value = (int)GameData.player.Spawn2.CurrentHP * 100 / (int)GameData.player.Spawn2.MaxHp;
                Spawn2LevelLBL.Text = "Level: " + GameData.player.Spawn2.Level.ToString();
            }
            if (GameData.player.Spawn2 != null) {
                Spawn3Panel.Show();

                Spawn3IMGBox.Image = GameData.player.Spawn3.MyImage;
                Spawn3NameLBL.Text = GameData.player.Spawn3.Name;
                Spawn3HPBar.Value = (int)GameData.player.Spawn3.CurrentHP * 100 / (int)GameData.player.Spawn3.MaxHp;
                Spawn3LevelLBL.Text = "Level: " + GameData.player.Spawn3.Level.ToString();
            }
        } // Update Stats Panel

        private void RoomDescriptionBox_TextChanged(object sender, EventArgs e) {

        }
        private void ActionLog_TextChanged(object sender, EventArgs e) {
            ActionLog.Select(ActionLog.Text.Length, 0);
            ActionLog.ScrollToCaret();
        } // Scroll to Log Bottom
        private void CombatLog_TextChanged(object sender, EventArgs e) {
            CombatLog.Select(CombatLog.Text.Length, 0);
            CombatLog.ScrollToCaret();
        } // Scroll to Log Bottom
    }
}
