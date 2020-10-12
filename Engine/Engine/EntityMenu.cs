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
    public partial class EntityMenu : Form
    {

        Dictionary<TextBox, EntityParam> ValuePairs = new Dictionary<TextBox, EntityParam>();

        public EntityMenu()
        {
            InitializeComponent();
        }

        public void Build(Entity ent)
        {
            label1.Text = ent.entityParams[0].value;
            List<EntityParam> entityParams = new List<EntityParam>();
            EntityParam[] entities = new EntityParam[ent.entityParams.Count];
            ent.entityParams.CopyTo(entities);

            foreach(EntityParam param in entities)
            {
                entityParams.Add(param);
            }

            entityParams.Reverse();
            foreach (EntityParam param in entityParams)
            {
                TextBox name = new TextBox();
                name.Text = param.name;
                name.ReadOnly = true;
                name.Dock = DockStyle.Top;
                panel1.Controls.Add(name);

                TextBox value = new TextBox();
                value.Dock = DockStyle.Top;
                value.Text = param.value;
                ValuePairs.Add(value, param);
                value.TextChanged += (s, e) => { ValuePairs[s as TextBox].value = ((TextBox)s).Text; };
                panel2.Controls.Add(value);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
