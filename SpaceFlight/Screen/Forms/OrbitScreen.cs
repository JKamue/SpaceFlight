using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFlight.Screen.Forms
{
    public partial class OrbitScreen : Form
    {
        public OrbitScreen()
        {
            InitializeComponent(); StartPosition = FormStartPosition.Manual;
            Left = 40;
            Top = 565;
        }

        private void OrbitScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        public Panel GetPanel() => pnlOrbitScreen;

        private void OrbitScreen_Activated(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                f.BringToFront();
            }
        }
    }
}
