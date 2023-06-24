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
    public partial class PlayerInventoryView : Form {
        Scene CurrentScene;
        int Selected = 0;
        public PlayerInventoryView(Scene currentScene) {
            InitializeComponent();
            CurrentScene = currentScene;
        }
        private void PlayerInventoryView_Load(object sender, EventArgs e) {
            CenterToParent();

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            YourInventoryLBL.Text = $"Your Inventory Weight: {GameData.player.CurrentCarryWeight} / {GameData.player.MaxCarryWeight}";

            RefreshBox();
        }

        private void DropButton_Click(object sender, EventArgs e) {
            DescriptionBox.Text = "";
            if (ItemListBox.Items.Count > 0) {
                Drop();
                RefreshBox();
            }
            else {
                LogBox.Text += $"{Environment.NewLine}You Have Nothing Left to Drop.";
            }
        }
        private void TakeAllButton_Click(object sender, EventArgs e) {
            DescriptionBox.Text = "";
            if (ItemListBox.Items.Count > 0) {
                CountBox.Value = GameData.player.MyInventory[Selected].Count;
                Drop();
                RefreshBox();
            }
            else {
                LogBox.Text += $"{Environment.NewLine}You Have Nothing Left to Drop.";
            }
        }
        private void UseButton_Click(object sender, EventArgs e) {

        }
        private void DoneButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ItemListBox_SelectedIndexChanged(object sender, EventArgs e) {
            Selected = ItemListBox.SelectedIndex;

            CountBox.Minimum = 1;
            CountBox.Maximum = GameData.player.MyInventory[Selected].Count;

            DescriptionBox.Text =
                $"{GameData.player.MyInventory[Selected].Item.Name}{Environment.NewLine}" +
                $"  {GameData.player.MyInventory[Selected].Item.Description}{Environment.NewLine}{Environment.NewLine}" +
                $"Weight: {GameData.player.MyInventory[Selected].Item.Weight} Unit(s) Per Item{Environment.NewLine}" +
                $"Weighs: {GameData.player.MyInventory[Selected].Item.Weight * GameData.player.MyInventory[Selected].Count} Unit(s) for The Stack";
        }
        private void Drop() {
            string Name = GameData.player.MyInventory[Selected].Item.Name;
            int Ammount = (int)CountBox.Value;
            if (Ammount > 1) {
                Name = GameData.player.MyInventory[Selected].Item.NamePlural;
            }

            if (CurrentScene.ItemsLocatedHere.Count > 0) {
                for (int i = 0; i < CurrentScene.ItemsLocatedHere.Count; i++) {
                    if (GameData.player.MyInventory[Selected].Item.Name == CurrentScene.ItemsLocatedHere[i].Item.Name) {
                        CurrentScene.ItemsLocatedHere[i].Count += Ammount;
                        break;
                    }
                    else if (i == CurrentScene.ItemsLocatedHere.Count - 1) {
                        CurrentScene.ItemsLocatedHere.Add(new InventoryItem(GameData.player.MyInventory[Selected].Item, Ammount));
                        break;
                    }
                }
            }
            else {
                CurrentScene.ItemsLocatedHere.Add(new InventoryItem(GameData.player.MyInventory[Selected].Item, Ammount));
            }
            LogBox.Text += $"{Environment.NewLine} x{Ammount} {Name} Removed From Your Inventory";

            GameData.player.MyInventory[Selected].Count -= Ammount;
            if (GameData.player.MyInventory[Selected].Count <= 0) {
                GameData.player.MyInventory.Remove(GameData.player.MyInventory[Selected]);
            }

            GameData.player.CurrentCarryWeight = Character.GetCarryWeight(GameData.player.MyInventory);
            YourInventoryLBL.Text = $"Your Inventory Weight: {GameData.player.CurrentCarryWeight} / {GameData.player.MaxCarryWeight}";
        }
        private void RefreshBox() {
            ItemListBox.Items.Clear();
            for (int I = 0; I < GameData.player.MyInventory.Count; I++) {
                string Name = GameData.player.MyInventory[I].Item.Name;
                if (GameData.player.MyInventory[I].Count > 1) {
                    Name = GameData.player.MyInventory[I].Item.NamePlural;
                }

                ItemListBox.Items.Add($"x{GameData.player.MyInventory[I].Count} {Name}");
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
