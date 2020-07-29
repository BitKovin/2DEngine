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
    public partial class EditorWindow : Form
    {
        public int x;
        public int y;
        string oldBrush;
        public EditorWindow()
        {
            InitializeComponent();
            //setPos += SetPos;
        }

        //public Action<int, int> setPos;

        public void SetPos(int x, int y)
        {
            this.SetDesktopLocation(x+8, y+31);
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Editor.EditorMain.entityType = comboBox1.Text;
            Console.WriteLine(comboBox1.Text);
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Editor.EditorMain.StartLevel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Editor.EditorMain.tool = Editor.Tool.enity;
            button3.Enabled = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Editor.EditorMain.tool = Editor.Tool.brush;
            button4.Enabled = false;
            button3.Enabled = true;
        }
    }
}
