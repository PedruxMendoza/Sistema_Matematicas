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
    public partial class Menu : Form
    {
        Incognita1 in1 = new Incognita1();
        Incognita2 in2 = new Incognita2();
        Incognita3 in3 = new Incognita3();
        FormulaCuadratica FC = new FormulaCuadratica();
        AyudaOrden1 help1 = new AyudaOrden1();
        AyudaOrden2 help2 = new AyudaOrden2();
        Ayuda2Incognitas helpinc2 = new Ayuda2Incognitas();
        Ayuda3Incognitas helpinc3 = new Ayuda3Incognitas();
        Creditos credits = new Creditos();

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void incognitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            in1.ShowDialog();
        }

        private void incognitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            in2.ShowDialog();
        }

        private void incognitasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            in3.ShowDialog();
        }

        private void segundoOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            FC.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void ecuacionesDe1IncognitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            help1.ShowDialog();
        }

        private void ecuacionesDe2IncognitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            help2.ShowDialog();
        }

        private void incognitasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            helpinc2.ShowDialog();
        }

        private void incognitasToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Hide();
            helpinc3.ShowDialog();
        }

        private void creditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            credits.ShowDialog();
        }
    }
}
