using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace E_DoV_V._1 {
    public class Scene {
        public SceneID ID;
        public SceneText SceneText;
        public Image Banner;
        public enum RoomType {Passive = 0, Hostile_Easy = 1, Hostile_Meduim = 2, Hostile_Hard = 3}
        public RoomType RType;
        public enum Directions { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest, Up, Down };
        public List<NavData> ExitList;
        public List<InventoryItem> ItemsLocatedHere;

        public Scene(SceneID id, SceneText sceneText, Image banner, RoomType Type) {
            ID = id;
            SceneText = sceneText;
            Banner = banner;
            RType = Type;
            ExitList = new List<NavData>();
            ItemsLocatedHere = new List<InventoryItem>();
        }
        public static void SceneHandeler(Scene CurrentScene, Form form, PictureBox Banner, TextBox DescriptionBox, List<Button> NavB, List<Button> ActionButtons) {
            #region Navigation
            foreach (Button button in NavB) {
                button.Visible = false;
            }

            Button N = NavB[0];
            Button NE = NavB[1];
            Button E = NavB[2];
            Button SE = NavB[3];
            Button S = NavB[4];
            Button SW = NavB[5];
            Button W = NavB[6];
            Button NW = NavB[7];
            Button U = NavB[8];
            Button D = NavB[9];

            form.Text = $"Egragoi: Dawn of Venandi - {CurrentScene.SceneText.Name} : " +
                $"{GameData.PlayerLocationID.X}'{GameData.PlayerLocationID.Y}'{GameData.PlayerLocationID.Z}'{GameData.PlayerLocationID.W}";
            Banner.Image = CurrentScene.Banner;
            DescriptionBox.Text = CurrentScene.SceneText.Description1;

            if (CurrentScene.ItemsLocatedHere.Count > 0) {
                DescriptionBox.Text += Environment.NewLine;
                DescriptionBox.Text += Environment.NewLine;
                DescriptionBox.Text += "Here You see:";
                for (int I = 0; I < CurrentScene.ItemsLocatedHere.Count; I++) {
                    string NM = CurrentScene.ItemsLocatedHere[I].Item.Name;
                    if (CurrentScene.ItemsLocatedHere[I].Count > 1) {
                        NM = CurrentScene.ItemsLocatedHere[I].Item.NamePlural;
                    }
                    DescriptionBox.Text += $"{Environment.NewLine}  x{CurrentScene.ItemsLocatedHere[I].Count} {NM}";
                }
            }

            for (int i = 0; i < CurrentScene.ExitList.Count; i++) {
                if (CurrentScene.ExitList[i].Direction == Directions.North) {
                    N.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.NorthEast) {
                    NE.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.East) {
                    E.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.SouthEast) {
                    SE.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.South) {
                    S.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.SouthWest) {
                    SW.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.West) {
                    W.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.NorthWest) {
                    NW.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.Up) {
                    U.Visible = true;
                }
                else if (CurrentScene.ExitList[i].Direction == Directions.Down) {
                    D.Visible = true;
                }
            }
            #endregion
            #region Actions
            foreach (Button button in ActionButtons) {
                button.Visible = false;
            }

            if (CurrentScene.ItemsLocatedHere.Count > 0) {
                ActionButtons[0].Text = "Take Item";
                ActionButtons[0].Visible = true;
            }
            if (CurrentScene.RType == RoomType.Passive) {
                ActionButtons[5].Text = "Rest";
                ActionButtons[5].Visible = true;
            }

            #endregion
        }
        public static Scene GetSceneByID(SceneID ID, List<Scene> Map) {
            for (int S = 0; S < Map.Count; S++) {
                if (ID.X == Map[S].ID.X && ID.Y == Map[S].ID.Y &&
                        ID.Z == Map[S].ID.Z && ID.W == Map[S].ID.W) {
                    return Map[S];
                }
            }
            return null;
        }
    }
    public class SceneText {
        public string Name, Description1;
        public SceneText(string name, string description1) {
            Name = name;
            Description1 = description1;
        }
    }
    public class SceneID {
        public float X, Y, Z, W;
        public SceneID(float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
    public class NavSPD{
        public float N, NE, E, SE, S, SW, W, NW, U, D;
        public NavSPD(float n, float ne, float e, float se, float s, float sw, float w, float nw, float u, float d) {
            N = n;
            NE = ne;
            E = e;
            SE = se;
            S = s;
            SW = w;
            NW = nw;
            U = u;
            D = d;
        }
    }
    public class NavData {
        public Scene.Directions Direction;
        public float Spd;
        public NavData(Scene.Directions direction, float spd) {
            Direction = direction;
            Spd = spd;
        }
    }
}
