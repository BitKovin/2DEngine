using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SFML.Window;


namespace Engine
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void EditorForm_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void drawingSurface1_Click(object sender, EventArgs e)
        {
            ActiveControl = drawingSurface1;
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Renderer.window.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => SaveAsFile());
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor.EditorMenu.New_OnClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Editor.EditorMenu.Entity_OnClick();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Editor.EditorMain.FileName != "")
            {
                Editor.EditorMenu.Save_OnClick();
            }else
            {
                Thread thread = new Thread(() => SaveAsFile());
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => LoadFile());
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            
        }

        void LoadFile()
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {

                    Editor.EditorMain.FileName = fbd.FileName;

                    Editor.EditorMenu.Load_OnClick();
                }
            }
            
        }

        void SaveAsFile()
        {
            using (var fbd = new SaveFileDialog())
            {
                fbd.Filter = "Map files (*.map)|*.map|All files (*.*)|*.*";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {

                    Editor.EditorMain.FileName = fbd.FileName;

                    Editor.EditorMenu.Save_OnClick();
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Editor.EditorMain.entityType = textBox2.Text;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ActiveControl = panel1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Editor.EditorMain.brushType = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Editor.EditorMenu.Brush_OnClick();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.LShift))
                if(e.KeyChar=='s')
                {
                    saveToolStripMenuItem_Click(null, null);
                }
        }
    }

    public class DrawingSurface : System.Windows.Forms.Control
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
    }
}
