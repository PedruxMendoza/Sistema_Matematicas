using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoProgra1Form
{
    public partial class BienvenidaSplash : Form
    {
        public BienvenidaSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                rectangleShape2.Width += 1;
                if (rectangleShape2.Width >= 755)
                {
                    timer1.Stop();
                    Menu main = new Menu();
                    Hide();
                    main.ShowDialog();
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
