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
    public partial class Incognita2 : Form
    {
        //Declaracion de Variables
        public double A, B, C, D, E, F, resulX, resulY, det, m;

        //Instanciamos(Llamamos la clase de las validaciones de los textbox
        Validaciones val = new Validaciones();

        public Incognita2()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {//Primero vereficamos si tenemos informacin en la variables de resultado
            if ((resulX == 0)||(resulY ==0))
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
                        if (B >= 0)
                        {
                            escribir.WriteLine("\nEcuacion 1: " + A + "x +" + B + "y = " + C);
                            if (E >= 0)
                            {
                                escribir.WriteLine("\nEcuacion 2: " + D + "x +" + E + "y = " + F);
                            }
                            else
                            {
                                escribir.WriteLine("\nEcuacion 2: " + D + "x " + E + "y = " + F);
                            }
                        }
                        else
                        {
                            escribir.WriteLine("\nEcuacion 1: " + A + "x " + B + "y = " + C);
                            if (E >= 0)
                            {
                                escribir.WriteLine("\nEcuacion 2: " + D + "x +" + E + "y = " + F);
                            }
                            else
                            {
                                escribir.WriteLine("\nEcuacion 2: " + D + "x " + E + "y = " + F);
                            }
                        }
                        escribir.WriteLine("\n====================================================================");
                        if (det != 0)
                        {
                            escribir.WriteLine("\nLos valores encontrados son:");
                            escribir.WriteLine("X = " + resulX);
                            escribir.WriteLine("Y = " + resulY);
                        }
                        else
                        {
                            m = D / A;
                            if (m * C == F)
                            {
                                escribir.WriteLine("\nLos valores encontrados son:");
                                escribir.WriteLine("X = Infinito");
                                escribir.WriteLine("Y = Infinito");
                                escribir.WriteLine("\nEl sistema tiene infinitas soluciones");
                            }
                            else
                            {
                                escribir.WriteLine("\nLos valores encontrados son:");
                                escribir.WriteLine("X = Imposible");
                                escribir.WriteLine("Y = Imposible");
                                escribir.WriteLine("\nEl sistema no tiene soluciones");
                            }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiamos los textbox y tambien dejamos los label en blancos
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtD.Clear();
            txtE.Clear();
            txtF.Clear();
            lblResultX.Text = "";
            lblResultY.Text = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {//Primero verificamos si no se ha dejado vacio los textbox 
            if ((string.IsNullOrEmpty(txtA.Text)) || (string.IsNullOrEmpty(txtB.Text)) || (string.IsNullOrEmpty(txtC.Text)) || (string.IsNullOrEmpty(txtD.Text)) || (string.IsNullOrEmpty(txtE.Text)) || (string.IsNullOrEmpty(txtF.Text)))
            {//Si es asi, se mandara un mensaje de que no podemos dejar valores en blanco
                MessageBox.Show("No deje valores en blanco, Favor introduzca un valor", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//Si no es asi y tenemos valores en los 3 textbox
            else
            {
                //Declaramos cada variable y convertimos la informacion del texbox a double 
                A = Double.Parse(txtA.Text);
                B = Double.Parse(txtB.Text);
                C = Double.Parse(txtC.Text);
                D = Double.Parse(txtD.Text);
                E = Double.Parse(txtE.Text);
                F = Double.Parse(txtF.Text);

                det = (A * E) - (B * D);
                if (det != 0)
                {
                    resulX = ((E * C) - (B * F)) / det;
                    resulY = ((A * F) - (D * C)) / det;
                    lblResultX.Text = resulX.ToString();
                    lblResultY.Text = resulY.ToString();
                }
                else
                {
                    m = D / A;
                    if (m * C == F)
                    {
                        lblResultX.Text = "Infinito";
                        lblResultY.Text = "Infinito";
                    }
                    else
                    {
                        lblResultX.Text = "Imposible";
                        lblResultY.Text = "Imposible";
                    }
                }
            }
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtD_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtE_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }

        private void txtF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Llamamos el metodo que nos sirve para ingresar solo numeros
            val.soloNumeros(e);
        }
    }
}
