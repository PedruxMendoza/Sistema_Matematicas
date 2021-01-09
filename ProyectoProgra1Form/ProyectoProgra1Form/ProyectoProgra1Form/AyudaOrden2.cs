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
    public partial class AyudaOrden2 : Form
    {
        public AyudaOrden2()
        {
            InitializeComponent();
        }

        private void AyudaOrden2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu main = new Menu();
            Hide();
            main.ShowDialog();
        }
    }
}
