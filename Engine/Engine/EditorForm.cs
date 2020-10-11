using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            
        }

        private void EditorForm_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void drawingSurface1_Click(object sender, EventArgs e)
        {

        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Renderer.window.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
