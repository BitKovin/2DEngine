using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.UI;
using SFML.System;
using SFML.Graphics;

using static Engine.UI.UiElement;

namespace Engine.Editor
{
    public class EditorMenu
    {
        public static UiInputField fileName;
        public static UiInputField entityName;
        public static UiInputField brushName;
        static UiButton entity;
        static UiButton brush;
        static UiButton Disable;
        public static UiText objName;

        static List<UiElement> EntityParams = new List<UiElement>();

        public static void Start()
        {

            #region Spawner
            /*
            #region panel
            UiPanel panel = new UiPanel();
            panel.originH = Origin.Left;
            panel.originV = Origin.Top;
            panel.size = new Vector2f(100,180);
            panel.position = new Vector2f(50, 90);
            panel.color = new Color(25, 25, 25, 250);
            panel.layer = -5;
            UiManager.objects.Add(panel);
            #endregion

            #region play
            UiButton play = new UiButton();
            play.originV = Origin.Top;
            play.position = new Vector2f(-14, 10);
            play.size = new Vector2f(24, 13);
            play.text = "play";
            play.SetFontSize(10);
            UiManager.objects.Add(play);
            play.OnClick += Play_OnClick;
            #endregion

            #region stop
            UiButton stop = new UiButton();
            stop.originV = Origin.Top;
            stop.position = new Vector2f(14, 10);
            stop.size = new Vector2f(24, 13);
            stop.text = "stop";
            stop.SetFontSize(10);
            UiManager.objects.Add(stop);
            stop.OnClick += Stop_OnClick;
            #endregion

            #region fileName
            fileName = new UiInputField();
            fileName.originV = Origin.Top;
            fileName.originH = Origin.Left;
            fileName.position = new Vector2f(50, 10);
            fileName.size = new Vector2f(92, 13);
            fileName.SetFontSize(10);
            fileName.text = "test";
            UiManager.objects.Add(fileName);
            #endregion

            #region load
            UiButton load = new UiButton();
            load.originV = Origin.Top;
            load.originH = Origin.Left;
            load.position = new Vector2f(84, 26);
            load.size = new Vector2f(24, 13);
            load.text = "load";
            load.SetFontSize(10);
            UiManager.objects.Add(load);
            load.OnClick += Load_OnClick;
            #endregion

            #region New
            UiButton New = new UiButton();
            New.originV = UiElement.Origin.Top;
            New.originH = UiElement.Origin.Left;
            New.position = new Vector2f(16, 26);
            New.size = new Vector2f(24, 13);
            New.text = "new";
            New.SetFontSize(10);
            UiManager.objects.Add(New);
            New.OnClick += New_OnClick;
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

            #region spawner
            UiText t_spawner = new UiText();
            t_spawner.originH = UiElement.Origin.Left;
            t_spawner.originV = UiElement.Origin.Top;
            t_spawner.position = new Vector2f(50,50);
            t_spawner.text = "SPAWNER";
            UiManager.objects.Add(t_spawner);
            #endregion

            #region Entity
            entity = new UiButton();
            entity.originV = UiElement.Origin.Top;
            entity.originH = UiElement.Origin.Left;
            entity.position = new Vector2f(50, 70);
            entity.size = new Vector2f(92, 15);
            entity.SetFontSize(15);
            entity.text = "ENTITY";
            entity.active = true;
            UiManager.objects.Add(entity);
            entity.OnClick += Entity_OnClick;
            #endregion

            #region EntityName
            entityName = new UiInputField();
            entityName.originV = UiElement.Origin.Top;
            entityName.originH = UiElement.Origin.Left;
            entityName.position = new Vector2f(50, 92);
            entityName.size = new Vector2f(92, 11);
            entityName.SetFontSize(10);
            entityName.text = "Player";
            UiManager.objects.Add(entityName);
            #endregion


            #region Brush
            brush = new UiButton();
            brush.originV = UiElement.Origin.Top;
            brush.originH = UiElement.Origin.Left;
            brush.position = new Vector2f(50, 120);
            brush.size = new Vector2f(92, 15);
            brush.SetFontSize(15);
            brush.text = "BRUSH";
            UiManager.objects.Add(brush);
            brush.OnClick += Brush_OnClick;
            #endregion

            #region EntityName
            brushName = new UiInputField();
            brushName.originV = UiElement.Origin.Top;
            brushName.originH = UiElement.Origin.Left;
            brushName.position = new Vector2f(50, 142);
            brushName.size = new Vector2f(92, 11);
            brushName.SetFontSize(10);
            brushName.text = "b_test";
            UiManager.objects.Add(brushName);
            #endregion

            #region Disable
            Disable = new UiButton();
            Disable.originV = UiElement.Origin.Top;
            Disable.originH = UiElement.Origin.Left;
            Disable.position = new Vector2f(50, 170);
            Disable.size = new Vector2f(92, 15);
            Disable.SetFontSize(15);
            Disable.text = "DISABLE";
            UiManager.objects.Add(Disable);
            Disable.OnClick += Disable_OnClick;
            Disable.active = false;
            #endregion
            */
            #endregion

            #region EntityMenu
            #region panel
            UiPanel panel2 = new UiPanel();
            panel2.originH = Origin.Right;
            panel2.originV = Origin.Top;
            panel2.size = new Vector2f(100, 200);
            panel2.position = new Vector2f(-50, 100);
            panel2.color = new Color(25, 25, 25, 250);
            panel2.layer = -5;
            UiManager.objects.Add(panel2);
            #endregion
            #region Name
            objName = new UiText();
            objName.SetFontSize(15);
            objName.originH = Origin.Right;
            objName.originV = Origin.Top;
            objName.position = new Vector2f(-50,10);
            objName.text = "test";
            UiManager.objects.Add(objName);
            #endregion
            #endregion

        }

        private static void Disable_OnClick()
        {
            EditorMain.tool = Tool.empty;
            entity.active = true;
            brush.active = true;
            Disable.active = false;
        }

        public static void New_OnClick()
        {
            EditorMain.baselevel = new Level();
            fileName.text = "Unnamed";
            EditorMain.StopLevel();
        }

        public static void BuildEntityMenu(Entity entity)
        {
            foreach (UiElement element in EntityParams)
                UiManager.objects.Remove(element);

            if (entity.entityParams==null) return;
            int i = 0;
            foreach(EntityParam param in entity.entityParams)
            {
                UiText text = new UiText();
                text.originH = Origin.Right;
                text.originV = Origin.Top;
                text.position = new Vector2f(-50, 40 + i * 40);
                text.text = param.name;
                text.SetFontSize(12);
                text.r_text.Style = Text.Styles.Bold;
                UiManager.objects.Add(text);
                EntityParams.Add(text);

                UiInputField inputField = new UiInputField();
                inputField.originH = Origin.Right;
                inputField.originV = Origin.Top;
                inputField.position = new Vector2f(-50, 55 + i * 40);
                inputField.size = new Vector2f(90, 13);
                inputField.text = param.value;
                inputField.SetFontSize(10);
                inputField.param = param;
                inputField.r_text.Style = Text.Styles.Italic;
                UiManager.objects.Add(inputField);
                EntityParams.Add(inputField);

                i++;
            }

        }

        public static void Entity_OnClick()
        {
            EditorMain.tool = Tool.enity;
        }

        public static void Brush_OnClick()
        {
            EditorMain.tool = Tool.brush;
        }

        public static void Save_OnClick()
        {
            SaveLoadMap.Save(EditorMain.baselevel, Editor.EditorMain.FileName);
        }

        public static void Load_OnClick()
        {
            try
            {
                SaveLoadMap.Load(EditorMain.baselevel, Editor.EditorMain.FileName);
                EditorMain.StopLevel();
            }catch(SystemException ex)
            {
                Console.WriteLine(ex);
            }
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
