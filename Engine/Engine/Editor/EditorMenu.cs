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
            #endregion

            #region stop
            UiButton stop = new UiButton();
            stop.originV = UiElement.Origin.Top;
            stop.position = new Vector2f(14, 10);
            stop.size = new Vector2f(24, 13);
            stop.text = "stop";
            stop.SetFontSize(10);
            UiManager.objects.Add(stop);
            #endregion
        }
    }
}
