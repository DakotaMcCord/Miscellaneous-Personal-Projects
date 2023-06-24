using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_DoV_V._1 {
    public partial class ExamineAndTakeView : Form {
        Scene CurrentScene;
        int Selected = 0;
        public ExamineAndTakeView(Scene currentScene) {
            InitializeComponent();
            CurrentScene = currentScene;
        }
        private void ExamineView_Load(object sender, EventArgs e) {
            CenterToParent();

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            YourInventoryLBL.Text = $"Your Inventory Weight: {GameData.player.CurrentCarryWeight} / {GameData.player.MaxCarryWeight}";

            RefreshBox();
        }

        private void TakeButton_Click(object sender, EventArgs e) {
            DescriptionBox.Text = "";
            if (ItemListBox.Items.Count > 0) {
                Take();
                RefreshBox();
            }
            else {
                LogBox.Text += $"{Environment.NewLine}There is Nothing Left to Take.";
            }
        }
        private void TakeAllButton_Click(object sender, EventArgs e) {
            DescriptionBox.Text = "";
            if (ItemListBox.Items.Count > 0) {
                CountBox.Value = CurrentScene.ItemsLocatedHere[Selected].Count;
                Take();
                RefreshBox();
            }
            else {
                LogBox.Text += $"{Environment.NewLine}There is Nothing Left to Take.";
            }
        }
        private void DoneButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ItemListBox_SelectedIndexChanged(object sender, EventArgs e) {
            Selected = ItemListBox.SelectedIndex;

            CountBox.Minimum = 1;
            CountBox.Maximum = CurrentScene.ItemsLocatedHere[Selected].Count;

            DescriptionBox.Text = 
                $"{CurrentScene.ItemsLocatedHere[Selected].Item.Name}{Environment.NewLine}" +
                $"  {CurrentScene.ItemsLocatedHere[Selected].Item.Description}{Environment.NewLine}{Environment.NewLine}" +
                $"Weight: {CurrentScene.ItemsLocatedHere[Selected].Item.Weight} Unit(s) Per Item{Environment.NewLine}" +
                $"Weighs: {CurrentScene.ItemsLocatedHere[Selected].Item.Weight* CurrentScene.ItemsLocatedHere[Selected].Count} Unit(s) for The Stack";
        }
        private void Take() {
            string Name = CurrentScene.ItemsLocatedHere[Selected].Item.Name;
            int Ammount = (int)CountBox.Value;
            if (Ammount > 1) {
                Name = CurrentScene.ItemsLocatedHere[Selected].Item.NamePlural;
            }

            if (GameData.player.CurrentCarryWeight + (Ammount * CurrentScene.ItemsLocatedHere[Selected].Item.Weight)  <= GameData.player.MaxCarryWeight) {
                if (GameData.player.MyInventory.Count > 0) {
                    for (int i = 0; i < GameData.player.MyInventory.Count; i++) {
                        if (GameData.player.MyInventory[i].Item.Name == CurrentScene.ItemsLocatedHere[Selected].Item.Name) {
                            GameData.player.MyInventory[i].Count += Ammount;
                            break;
                        }
                        else if (i == GameData.player.MyInventory.Count-1) {
                            GameData.player.MyInventory.Add(new InventoryItem(CurrentScene.ItemsLocatedHere[Selected].Item, Ammount));
                            break;
                        }
                    }
                }
                else {
                    GameData.player.MyInventory.Add(new InventoryItem(CurrentScene.ItemsLocatedHere[Selected].Item, Ammount));
                }
                LogBox.Text += $"{Environment.NewLine} x{Ammount} {Name} added to Your Inventory";

                CurrentScene.ItemsLocatedHere[Selected].Count -= Ammount;
                if (CurrentScene.ItemsLocatedHere[Selected].Count <= 0) {
                    CurrentScene.ItemsLocatedHere.Remove(CurrentScene.ItemsLocatedHere[Selected]);
                }
            }
            else {
                LogBox.Text += $"{Environment.NewLine}You Cannot Carry x{Ammount} More {CurrentScene.ItemsLocatedHere[Selected].Item.NamePlural}";
            }

            GameData.player.CurrentCarryWeight = Character.GetCarryWeight(GameData.player.MyInventory);
            YourInventoryLBL.Text = $"Your Inventory Weight: {GameData.player.CurrentCarryWeight} / {GameData.player.MaxCarryWeight}";
        }
        private void RefreshBox() {
            ItemListBox.Items.Clear();
            for (int I = 0; I < CurrentScene.ItemsLocatedHere.Count; I++) {
                string Name = CurrentScene.ItemsLocatedHere[I].Item.Name;
                if (CurrentScene.ItemsLocatedHere[I].Count > 1) {
                    Name = CurrentScene.ItemsLocatedHere[I].Item.NamePlural;
                }

                ItemListBox.Items.Add($"x{CurrentScene.ItemsLocatedHere[I].Count} {Name}");
            }
            if (Selected >= ItemListBox.Items.Count) {
                Selected = ItemListBox.Items.Count - 1;
            }

            ItemListBox.SelectedIndex = Selected;
        }

        private void LogBox_TextChanged(object sender, EventArgs e) {
            LogBox.Select(LogBox.Text.Length, 0);
            LogBox.ScrollToCaret();
        }
    }
}