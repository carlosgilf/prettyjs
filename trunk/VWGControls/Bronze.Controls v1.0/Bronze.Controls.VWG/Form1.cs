#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Bronze.Controls.VWG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.mobjImageProcessor.SelectionChanged += new System.EventHandler(this.mobjImageProcessor_SelectionChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.mobjImageProcessor.ImagePath = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("pool.jpg");
            //this.mobjImageProcessor.Selection = new Rectangle(20, 20, 50, 50);
            //mobjImageProcessor.BgColor = Color.Blue;
            //mobjImageProcessor.BgOpacity = 0.3F;
        }

        private void mobjImageProcessor_SelectionChanged(object sender, EventArgs e)
        {
            label1.Text = mobjImageProcessor.Selection.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mobjImageProcessor.BgColor = this.txtColor.BackColor;
            mobjImageProcessor.BgOpacity = Convert.ToSingle(this.txtOpcail.Text);
            mobjImageProcessor.AspectRatio = Convert.ToSingle(this.txtAspectRatio.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mobjImageProcessor.Selection.ToString());
        }

        private void txtColor_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog((a, b) =>
            {
                if (colorDialog1.DialogResult == Gizmox.WebGUI.Forms.DialogResult.OK)
                {
                    this.txtColor.BackColor = colorDialog1.Color;

                }
            });
        }

    }
}