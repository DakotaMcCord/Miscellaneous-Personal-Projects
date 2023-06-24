using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace E_DoV_V._1 {
    public class GameData {
        public static Player player;
        public static Scene CurrentScene;
        public static SceneID PlayerLocationID;

        public static List<Button> NavB = new List<Button>();
        public static List<Button> ActionButtons = new List<Button>();
        public static List<Button> CombatButtons = new List<Button>();
        public static List<PictureBox> VSRelay = new List<PictureBox>();

        static GameData() {
            LoadImages();
            LoadCreatures();

            Creature creature = Creature.GetCreatureByID("Blyth");
            Creature creature1 = new Blyth(creature.ID, creature.Name, creature.Description, creature.MyImage, creature.MaxHp, creature.CurrentHP, creature.Level, creature.abillity1, creature.abillity2);
            player = new Player("PLR", "Player", "",null, creature1, null, null, 0, 50);
            player.CurrentCarryWeight = Character.GetCarryWeight(player.MyInventory);

            LoadItems();
            LoadMap();

            PlayerLocationID = new SceneID(8,4,0,0);
        }

        public static readonly List<Image> IMGAssets = new List<Image>();
        public static readonly string
            ErrorImage_Path = @"Assets\Sprites\Q.png",
            Dead_Ghost_Path = @"Assets\Sprites\Dead_Ghost.png",
            Blyth_Path = @"Assets\Sprites\Blyth.png";

        private static void LoadImages() {
            IMGAssets.Add(Image.FromFile(ErrorImage_Path));
            IMGAssets[0].Tag = $"Err*{ErrorImage_Path}";

            IMGAssets.Add(Image.FromFile(Dead_Ghost_Path));
            IMGAssets[1].Tag = $"DG*{Dead_Ghost_Path}";

            IMGAssets.Add(Image.FromFile(Blyth_Path));
            IMGAssets[2].Tag = $"Blyth*{Blyth_Path}";
        }
        public static Image GetIMGByTag(string Tag) {
            Image image;
            for (int i = 0; i < IMGAssets.Count; i++) {
                if (Tag == IMGAssets[i].Tag.ToString().Split('*')[0]) {
                    image = Image.FromFile(IMGAssets[i].Tag.ToString().Split('*')[1]);
                    image.Tag = IMGAssets[i].Tag;
                    return image;
                }
            }
            image = Image.FromFile(IMGAssets[0].Tag.ToString().Split('*')[1]); ;
            image.Tag = IMGAssets[0].Tag;
            return image;
        }

        public static List<Scene> TMap = new List<Scene>();
        private static void LoadMap() {
            #region Storage Hut
            TMap.Add(new Scene(
                new SceneID(3, 5, 0, 0),
                new SceneText(
                    "Storage Hut",
                    "A dilapidated storage hut. Made of oak logs stacked on end, barrels surround you, " +
                    "shelves of tools, and a fan spins lazily above your head. Barrels line the wall surrounding " +
                    "the door south, with a window punctuates the door north."),
                GetIMGByTag("Err"), Scene.RoomType.Passive));
            TMap[0].ExitList.Add(new NavData(Scene.Directions.North, 1));
            TMap[0].ExitList.Add(new NavData(Scene.Directions.South, 1));

            TMap[0].ItemsLocatedHere.Add(new InventoryItem(Object.GetObjectByName("Fan"), 2));
            TMap[0].ItemsLocatedHere.Add(new InventoryItem(Object.GetObjectByName("Drill"), 1));
            TMap[0].ItemsLocatedHere.Add(new InventoryItem(Object.GetObjectByName("Barrel"), 6));
            TMap[0].ItemsLocatedHere.Add(new InventoryItem(Object.GetObjectByName("Screw Driver"), 1));
            TMap[0].ItemsLocatedHere.Add(new InventoryItem(Object.GetObjectByName("Screw"), 31));
            TMap[0].ItemsLocatedHere.Add(new InventoryItem(Object.GetObjectByName("Cup"), 4));
            TMap[0].ItemsLocatedHere.Add(new InventoryItem(Object.GetObjectByName("Wrench"), 2));
            #endregion // 0
            #region Ruined house
            TMap.Add(new Scene(
                new SceneID(5, 9, 0, 0),
                new SceneText(
                    "Ruined house",
                    "A ruined house. Brick crumbles as time passes on. The only thing left at this point, is half a wall, and the window sill, without a window. The old wood beneath your feet creak as you walk across it."),
                GetIMGByTag("Err"), Scene.RoomType.Passive));
            TMap[1].ExitList.Add(new NavData(Scene.Directions.North, 1));
            TMap[1].ExitList.Add(new NavData(Scene.Directions.South, 1));
            #endregion // 1
            #region River
            TMap.Add(new Scene(
                new SceneID(5, 18, 0, 0),
                new SceneText(
                    "River",
                    "Rushing river. The river flows quickly, Trees line the sides, and the dirt bank is shallow and dry."),
                GetIMGByTag("Err"), Scene.RoomType.Passive));
            TMap[2].ExitList.Add(new NavData(Scene.Directions.North, 1));
            TMap[2].ExitList.Add(new NavData(Scene.Directions.South, 1));
            #endregion
            #region Bridge
            TMap.Add(new Scene(
                new SceneID(13, 4, 0, 0),
                new SceneText(
                    "Bridge",
                    "A large bridge suspended over a lake. You see buildings far off to the east, a river south, and more woods to the west."),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Hard));
            //TMap[3].ExitList.Add(new NavData(Scene.Directions.East, 1));
            TMap[3].ExitList.Add(new NavData(Scene.Directions.South, 1));
            TMap[3].ExitList.Add(new NavData(Scene.Directions.West, 1));
            #endregion
            #region Path (3 - 4)
            TMap.Add(new Scene(
                new SceneID(3, 4, 0, 0),
                new SceneText(
                    "Path (3 - 4)",
                    "The Path Leads East and South."),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Easy));
            TMap[4].ExitList.Add(new NavData(Scene.Directions.East, 5));
            TMap[4].ExitList.Add(new NavData(Scene.Directions.South, 1));
            #endregion
            #region Path (8 - 4)
            TMap.Add(new Scene(
                new SceneID(8, 4, 0, 0),
                new SceneText(
                    "Path (8 - 4)",
                    "The Path Leads East and West"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Meduim));
            TMap[5].ExitList.Add(new NavData(Scene.Directions.East, 4));
            TMap[5].ExitList.Add(new NavData(Scene.Directions.West, 5));
            #endregion
            #region Path (12 - 4)
            TMap.Add(new Scene(
                new SceneID(12, 4, 0, 0),
                new SceneText(
                    "Path (12 - 4)",
                    "The Path Leads  East and West"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Easy));
            TMap[6].ExitList.Add(new NavData(Scene.Directions.East, 1));
            TMap[6].ExitList.Add(new NavData(Scene.Directions.West, 4));
            #endregion
            #region Path (13 - 5)
            TMap.Add(new Scene(
                new SceneID(13, 5, 0, 0),
                new SceneText(
                    "Path (13 - 5)",
                    "The Path Leads North and South"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Hard));
            TMap[7].ExitList.Add(new NavData(Scene.Directions.North, 1));
            TMap[7].ExitList.Add(new NavData(Scene.Directions.South, 7));
            #endregion
            #region Path (13 - 12)
            TMap.Add(new Scene(
                new SceneID(13, 12, 0, 0),
                new SceneText(
                    "Path (13 - 12)",
                    "The Path Leads  North and South"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Hard));
            TMap[8].ExitList.Add(new NavData(Scene.Directions.North, 7));
            TMap[8].ExitList.Add(new NavData(Scene.Directions.South, 6));
            #endregion
            #region Path (13 - 18)
            TMap.Add(new Scene(
                new SceneID(13, 18, 0, 0),
                new SceneText(
                    "Path (13 - 18)",
                    "The Path Leads North and South-West"),
                GetIMGByTag("Err"), Scene.RoomType.Passive));
            TMap[9].ExitList.Add(new NavData(Scene.Directions.North, 6));
            TMap[9].ExitList.Add(new NavData(Scene.Directions.SouthWest, 1));
            #endregion
            #region Path (12 - 19)
            TMap.Add(new Scene(
                new SceneID(12, 19, 0, 0),
                new SceneText(
                    "Path (12 - 19)",
                    "The Path Leads North-East and West"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Easy));
            TMap[10].ExitList.Add(new NavData(Scene.Directions.NorthEast, 1));
            TMap[10].ExitList.Add(new NavData(Scene.Directions.West, 7));
            #endregion
            #region Path (5 - 19)
            TMap.Add(new Scene(
                new SceneID(5, 19, 0, 0),
                new SceneText(
                    "Path (5 - 19)",
                    "The Path Leads  North and East"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Meduim));
            TMap[11].ExitList.Add(new NavData(Scene.Directions.North, 1));
            TMap[11].ExitList.Add(new NavData(Scene.Directions.East, 7));
            #endregion
            #region Path (5 - 17)
            TMap.Add(new Scene(
                new SceneID(5, 17, 0, 0),
                new SceneText(
                    "Path (5 - 17)",
                    "The Path Leads North and South"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Meduim));
            TMap[12].ExitList.Add(new NavData(Scene.Directions.North, 4));
            TMap[12].ExitList.Add(new NavData(Scene.Directions.South, 1));
            #endregion
            #region Path (5 - 13)
            TMap.Add(new Scene(
                new SceneID(5, 13, 0, 0),
                new SceneText(
                    "Path (5 - 13)",
                    "The Path Leads North and South"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Meduim));
            TMap[13].ExitList.Add(new NavData(Scene.Directions.North, 3));
            TMap[13].ExitList.Add(new NavData(Scene.Directions.South, 4));
            #endregion
            #region Path (5 - 10)
            TMap.Add(new Scene(
                new SceneID(5, 10, 0, 0),
                new SceneText(
                    "Path (5 - 10)",
                    "The Path Leads North and South"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Easy));
            TMap[14].ExitList.Add(new NavData(Scene.Directions.North, 1));
            TMap[14].ExitList.Add(new NavData(Scene.Directions.South, 3));
            #endregion
            #region Path (5 - 8)
            TMap.Add(new Scene(
                new SceneID(5, 8, 0, 0),
                new SceneText(
                    "Path (5 - 8)",
                    "The Path Leads South and North-West"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Easy));
            TMap[15].ExitList.Add(new NavData(Scene.Directions.South, 1));
            TMap[15].ExitList.Add(new NavData(Scene.Directions.NorthWest, 2));
            #endregion
            #region Path (3 - 6)
            TMap.Add(new Scene(
                new SceneID(3, 6, 0, 0),
                new SceneText(
                    "Path (3 - 6)",
                    "The Path Leads North and South-East"),
                GetIMGByTag("Err"), Scene.RoomType.Hostile_Easy));
            TMap[16].ExitList.Add(new NavData(Scene.Directions.North, 1));
            TMap[16].ExitList.Add(new NavData(Scene.Directions.SouthEast, 2));
            #endregion
        }

        public static readonly List<Object> MasterItemList = new List<Object>();
        private static void LoadItems() {
            MasterItemList.Add(new Object("", "Fan", "It Blows Things", null, "Fans", 1, 0));
            MasterItemList.Add(new Object("", "Drill", "Drills Drill", null, "Drills", 1, 0));
            MasterItemList.Add(new Object("", "Barrel", "Its like a Giant Box", null, "Barrels", 1, 0));
            MasterItemList.Add(new Object("", "Screw Driver", "It Drives Screws", null, "Screw Drivers", 1, 0));
            MasterItemList.Add(new Object("", "Screw", "It  Can be 'Screwd'", null, "Screws", 1, 0));
            MasterItemList.Add(new Object("", "Cup", "Holds Liquids Sometimes", null, "Cups", 1, 0));
            MasterItemList.Add(new Object("", "Wrench", "Its Just a Wrench in the Works", null, "Wrenches", 1, 0));

        }

        public static readonly List<Creature> MasterCreatureList = new List<Creature>();
        private static void LoadCreatures() {
            MasterCreatureList.Add(new Blyth("Blyth", "Blyth", "Eye Creature", GameData.GetIMGByTag("Blyth"), 50, 50, 1,
                new Abillity("TestDMG", "Eye Beam Damage", 1, 10), new Abillity("TestHeal", "Healer's Healing", -1, -15)));
        }
    }
}
