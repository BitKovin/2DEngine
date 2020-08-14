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
            panel.originH = panel.Left;
            panel.size = new Vector2f(150,Constants.BaseResolution.Y);
            panel.position = new Vector2f(75, 0);
            panel.color = new Color(25, 25, 25, 250);
            panel.layer = -1;
            UiManager.objects.Add(panel);
            #endregion

            #region play
            UiButton play = new UiButton();
            play.originH = play.Left;
            play.originV = play.Top;
            //play.position = new Vector2f(50,20);
            play.size = new Vector2f(30, 10);
            UiManager.objects.Add(play);
            #endregion
        }
    }
}
