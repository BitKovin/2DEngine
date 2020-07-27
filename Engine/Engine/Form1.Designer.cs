using System.Windows.Forms;
namespace Engine
{
    partial class EditorWindow:Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test");
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.t_Entities = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Play = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(326, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(283, 102);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(56, 183);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // t_Entities
            // 
            this.t_Entities.AutoSize = true;
            this.t_Entities.Location = new System.Drawing.Point(13, 83);
            this.t_Entities.Name = "t_Entities";
            this.t_Entities.Size = new System.Drawing.Size(41, 13);
            this.t_Entities.TabIndex = 8;
            this.t_Entities.Text = "Entities";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Null",
            "Player"});
            this.comboBox1.Location = new System.Drawing.Point(16, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(13, 40);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 10;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(351, 560);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.t_Entities);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "EditorWindow";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private ListView listView1;
        private Label t_Entities;
        protected ComboBox comboBox1;
        private Button Play;
    }
}