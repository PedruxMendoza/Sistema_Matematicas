using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoProgra1Form
{
    class Validaciones
    {
        //Metodo que sirve para aceptar solo letras
        public void soloLetras(KeyPressEventArgs e)
        {//Al momento que presionamos una tecla de tipo letra de nuestro teclado 
            //Si la tecla que presionamos fue una letra
            if (Char.IsLetter(e.KeyChar))
            {//Lo reconocera y permitira que se presione
                e.Handled = false;
            }
            //Pero si teclamos una tecla de control como por ejemplo el backspaces
            else if (Char.IsControl(e.KeyChar))
            {//Lo reconocera y permitira que se presione
                e.Handled = false;
            }
            //Pero si teclamos una tecla de control como por ejemplo el punto
            else if (Char.IsPunctuation(e.KeyChar))
            {//Lo reconocera y permitira que se presione
                e.Handled = false;
            }
            //Pero si teclamos otra tecla como por ejemplo el numero
            else
            {//El programa no lo permitira y nos dar aun aviso de que solo introduzcamos letras
                e.Handled = true;
                MessageBox.Show("Introducir solo letras", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //Metodo que sirve para aceptar solo numeros
        public void soloNumeros(KeyPressEventArgs e)
        {//Al momento que presionamos una tecla numerica de nuestro teclado 
            //Si la tecla que presionamos fue una letra
            if (Char.IsDigit(e.KeyChar))
            {//Lo reconocera y permitira que se presione
                e.Handled = false;
            }
            //Pero si teclamos una tecla de control como por ejemplo el backspaces
            else if (Char.IsControl(e.KeyChar))
            {//Lo reconocera y permitira que se presione
                e.Handled = false;
            }
            //Pero si teclamos una tecla de control como por ejemplo el punto
            else if (Char.IsPunctuation(e.KeyChar))
            {//Lo reconocera y permitira que se presione
                e.Handled = false;
            }
            //Pero si teclamos otra tecla como por ejemplo una letra
            else
            {//El programa no lo permitira y nos dar aun aviso de que solo introduzcamos letras
                e.Handled = true;
                MessageBox.Show("Introducir solo numeros", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
