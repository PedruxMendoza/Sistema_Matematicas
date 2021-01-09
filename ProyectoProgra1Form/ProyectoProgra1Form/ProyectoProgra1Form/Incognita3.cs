using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Se incluya la librería de entrada / salida para poder utilizar las clases de lectura / escritura
using System.IO;
//Se incluye la librería de diagnostico para poder utilizar las clase de proceso
using System.Diagnostics;

namespace ProyectoProgra1Form
{
    public partial class Incognita3 : Form
    {
        public Incognita3()
        {
            InitializeComponent();
        }
        //Declaracion de Variables
        public double x1, y1, z1, re1, x2, y2, z2, re2, x3, y3, z3, re3, resulX, resulY, resulZ, det;

        private void btnGuardar_Click(object sender, EventArgs e)
        {//Primero vereficamos si tenemos informacin en la variables de resultado
            if ((resulX == 0) || (resulY == 0))
            {//Si no es asi pues le diremos al programa que no se puede guardar hasta que calcule primero su ecuacion
                MessageBox.Show("Primero debe calcular su ecuacion", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//Si no es asi y tenemos informacion de dicha variable
            else
            {
                //Luego llamamdos el control que nos servira para guardar el archivo
                SaveFileDialog archivo = new SaveFileDialog();
                //Agregamos un pequeño filtro para que este nos guarde solo archivos de textos
                archivo.Filter = "Documento de texto plano (*.txt)|*.txt";
                //Si el usuario presiona el boton de ok
                if (archivo.ShowDialog() == DialogResult.OK)
                {//Verificamos que el archivo no tenga espacio en blanco
                    if (string.IsNullOrEmpty(archivo.FileName))
                    {//Si tiene valor en blanco o es nulo nos avisara un mensaje de que el archivo no se puede guardar ya que no podemos dejar un archivo en blanco
                        MessageBox.Show("No puedes dejar el campo vacio", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {//Si no es asi y tenemos un nombre al archivo creamos ese archivo con el nombre que nosotros le asignamos y comenzamos a escribir
                        StreamWriter escribir = new StreamWriter(archivo.FileName, true);
                        escribir.WriteLine("\nSu sistemas de ecuaciones son:");
                        if (y1 >= 0)
                        {
                            if (z1 >= 0)
                            {
                                escribir.WriteLine("\nEcuacion 1: " + x1 + "x +" + y1 + "y +" + z1 + "z = " + re1);
                                if (y2 >= 0)
                                {
                                    if (z2 >= 0)
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x +" + y2 + "y +" + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x +" + y2 + "y " + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y + " + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y + " + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (z2 >= 0)
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x " + y2 + "y +" + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x " + y2 + "y " + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                escribir.WriteLine("\nEcuacion 1: " + x1 + "x +" + y1 + "y " + z1 + "z = " + re1);
                                if (y2 >= 0)
                                {
                                    if (z2 >= 0)
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x +" + y2 + "y +" + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x +" + y2 + "y " + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (z2 >= 0)
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x " + y2 + "y +" + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x " + y2 + "y " + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (z1 >= 0)
                            {
                                escribir.WriteLine("\nEcuacion 1: " + x1 + "x " + y1 + "y +" + z1 + "z = " + re1);
                                if (y2 >= 0)
                                {
                                    if (z2 >= 0)
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x +" + y2 + "y +" + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x +" + y2 + "y " + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (z2 >= 0)
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x " + y2 + "y +" + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x " + y2 + "y " + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                escribir.WriteLine("\nEcuacion 1: " + x1 + "x " + y1 + "y " + z1 + "z = " + re1);
                                if (y2 >= 0)
                                {
                                    if (z2 >= 0)
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x +" + y2 + "y +" + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x +" + y2 + "y " + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (z2 >= 0)
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x " + y2 + "y +" + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        escribir.WriteLine("\nEcuacion 2: " + x2 + "x " + y2 + "y " + z2 + "z = " + re2);
                                        if (y3 >= 0)
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x +" + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                        else
                                        {
                                            if (z3 >= 0)
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y +" + z3 + "z = " + re3);
                                            }
                                            else
                                            {
                                                escribir.WriteLine("\nEcuacion 3: " + x3 + "x " + y3 + "y " + z3 + "z = " + re3);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        escribir.WriteLine("\n====================================================================");
                        if (det != 0)
                        {
                            escribir.WriteLine("\nLos valores encontrados son:");
                            escribir.WriteLine("X = " + resulX);
                            escribir.WriteLine("Y = " + resulY);
                            escribir.WriteLine("Z = " + resulZ);
                        }
                        else
                        {
                            escribir.WriteLine("\nLos valores encontrados son");
                            escribir.WriteLine("X = Imposible");
                            escribir.WriteLine("Y = Imposible");
                            escribir.WriteLine("Z = Imposible");
                            escribir.WriteLine("\nEl sistema no tiene soluciones");
                        }//Y cerramos la escritura del archivo
                        escribir.Close();
                        //Luego de cerrar la escritura del archivo nos aparecera un mensaje que nos dira si queremos abrir el archivo que creamos
                        DialogResult abrir = MessageBox.Show("Desea abrir que acaba de crear?", "Abrir Archivo", MessageBoxButtons.YesNo);
                        if (abrir == DialogResult.Yes)
                        {//Si seleccionamos que si se nos abrira el archivo que creamos
                            Process.Start(archivo.FileName);
                        }
                        else
                        {//De lo contrario nos creara otro mensaje que el archivo a sido creado correctamente
                            MessageBox.Show("Archivo Creado Exitosamente", "Crear Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu main = new Menu();
            Hide();
            main.ShowDialog();
        }

        private void Incognita1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {//Primero verificamos si no se ha dejado vacio los textbox 
            if ((string.IsNullOrEmpty(txtX1.Text)) || (string.IsNullOrEmpty(txtY1.Text)) || (string.IsNullOrEmpty(txtZ1.Text)) || (string.IsNullOrEmpty(txtResul1.Text)) 
                || (string.IsNullOrEmpty(txtX2.Text)) || (string.IsNullOrEmpty(txtY2.Text)) || (string.IsNullOrEmpty(txtZ2.Text)) || (string.IsNullOrEmpty(txtResul2.Text))
                || (string.IsNullOrEmpty(txtX3.Text)) || (string.IsNullOrEmpty(txtY3.Text)) || (string.IsNullOrEmpty(txtZ3.Text)) || (string.IsNullOrEmpty(txtResul3.Text)))
            {//Si es asi, se mandara un mensaje de que no podemos dejar valores en blanco
                MessageBox.Show("No deje valores en blanco, Favor introduzca un valor", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//Si no es asi y tenemos valores en los 3 textbox
            else
            {
                //Declaramos cada variable y convertimos la informacion del texbox a double 
                x1 = Double.Parse(txtX1.Text);
                y1 = Double.Parse(txtY1.Text);
                z1 = Double.Parse(txtZ1.Text);
                re1 = Double.Parse(txtResul1.Text);
                x2 = Double.Parse(txtX2.Text);
                y2 = Double.Parse(txtY2.Text);
                z2 = Double.Parse(txtZ2.Text);
                re2 = Double.Parse(txtResul2.Text);
                x3 = Double.Parse(txtX3.Text);
                y3 = Double.Parse(txtY3.Text);
                z3 = Double.Parse(txtZ3.Text);
                re3 = Double.Parse(txtResul3.Text);

                det = (x1 * y2 * z3) + (x2 * y3 * z1) + (x3 * y1 * z2) - (z1 * y2 * x3) - (z2 * y3 * x1) - (z3 * y1 * x2);
                if (det != 0)
                {
                    resulX = ((re1 * y2 * z3) + (re2 * y3 * z1) + (re3 * y1 * z2) - (z1 * y2 * re3) - (z2 * y3 * re1) - (z3 * y1 * re2)) / det;
                    resulY = ((x1 * re2 * z3) + (x2 * re3 * z1) + (x3 * re1 * z2) - (z1 * re2 * x3) - (z2 * re3 * x1) - (z3 * re1 * x2)) / det;
                    resulZ = ((x1 * y2 * re3) + (x2 * y3 * re1) + (x3 * y1 * re2) - (re1 * y2 * x3) - (re2 * y3 * x1) - (re3 * y1 * x2)) / det;
                    lblResultX.Text = resulX.ToString();
                    lblResultY.Text = resulY.ToString();
                    lblResultZ.Text = resulZ.ToString();
                }
                else
                {
                    lblResultX.Text = "Imposible";
                    lblResultY.Text = "Imposible";
                    lblResultZ.Text = "Imposible";
                }
            }

        }

        //Instanciamos(Llamamos la clase de las validaciones de los textbox
        Validaciones val = new Validaciones();

        private void txtX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtY1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtZ1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtResul1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtY2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtZ2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtResul2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtY3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtZ3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtResul3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiamos los textbox y tambien dejamos los label en blancos
            txtX1.Clear();
            txtY1.Clear();
            txtZ1.Clear();
            txtResul1.Clear();
            txtX2.Clear();
            txtY2.Clear();
            txtZ2.Clear();
            txtResul2.Clear();
            txtX3.Clear();
            txtY3.Clear();
            txtZ3.Clear();
            txtResul3.Clear();
            lblResultX.Text = "";
            lblResultY.Text = "";
            lblResultZ.Text = "";
        }
    }
}
