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
            Editor.EditorMain.Test();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
