using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.UI;
using SFML.System;
using SFML.Graphics;

namespace Engine.Editor
{
    class EditorMenu
    {
        public static UiInputField fileName;
        public static void Start()
        {
            #region panel
            UiPanel panel = new UiPanel();
            panel.originH = UiElement.Origin.Left;
            panel.size = new Vector2f(100,Constants.BaseResolution.Y);
            panel.position = new Vector2f(50, 0);
            panel.color = new Color(25, 25, 25, 250);
            panel.layer = 0;
            UiManager.objects.Add(panel);
            #endregion

            #region play
            UiButton play = new UiButton();
            play.originV = UiElement.Origin.Top;
            play.position = new Vector2f(-14, 10);
            play.size = new Vector2f(24, 13);
            play.text = "play";
            play.SetFontSize(10);
            UiManager.objects.Add(play);
            play.OnClick += Play_OnClick;
            #endregion

            #region stop
            UiButton stop = new UiButton();
            stop.originV = UiElement.Origin.Top;
            stop.position = new Vector2f(14, 10);
            stop.size = new Vector2f(24, 13);
            stop.text = "stop";
            stop.SetFontSize(10);
            UiManager.objects.Add(stop);
            stop.OnClick += Stop_OnClick;
            #endregion

            #region fileName
            fileName = new UiInputField();
            fileName.originV = UiElement.Origin.Top;
            fileName.originH = UiElement.Origin.Left;
            fileName.position = new Vector2f(50, 10);
            fileName.size = new Vector2f(92, 13);
            fileName.SetFontSize(10);
            fileName.text = "test";
            UiManager.objects.Add(fileName);
            #endregion

            #region load
            UiButton load = new UiButton();
            load.originV = UiElement.Origin.Top;
            load.originH = UiElement.Origin.Left;
            load.position = new Vector2f(84, 26);
            load.size = new Vector2f(24, 13);
            load.text = "load";
            load.SetFontSize(10);
            UiManager.objects.Add(load);
            load.OnClick += Load_OnClick;
            #endregion

            #region save
            UiButton save = new UiButton();
            save.originV = UiElement.Origin.Top;
            save.originH = UiElement.Origin.Left;
            save.position = new Vector2f(57, 26);
            save.size = new Vector2f(24, 13);
            save.text = "save";
            save.SetFontSize(10);
            UiManager.objects.Add(save);
            save.OnClick += Save_OnClick;
            #endregion

        }

        private static void Save_OnClick()
        {
            SaveLoadMap.Save(EditorMain.baselevel, fileName.text);
        }

        private static void Load_OnClick()
        {
            SaveLoadMap.Load(EditorMain.baselevel, fileName.text);
        }

        private static void Stop_OnClick()
        {
            EditorMain.StopLevel();
        }

        private static void Play_OnClick()
        {
            EditorMain.StartLevel();
        }
    }
}
