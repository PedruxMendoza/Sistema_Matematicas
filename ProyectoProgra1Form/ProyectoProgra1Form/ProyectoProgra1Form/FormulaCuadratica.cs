using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Se incluye la librería de entrada / salida para poder utilizar las clases de lectura / escritura
using System.IO;
//Se incluye la librería de diagnostico para poder utilizar las clase de proceso
using System.Diagnostics;

namespace ProyectoProgra1Form
{
    public partial class FormulaCuadratica : Form
    {
        //Declaracion de Variables
        public double a, b, c, x1, x2, disc, rCompleja;

        //Instanciamos(Llamamos la clase de las validaciones de los textbox
        Validaciones val = new Validaciones();

        public FormulaCuadratica()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {//Primero vereficamos si tenemos informacin en la variables de resultado
            if ((x1 == 0) || (x2 == 0))
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
                        if (b >= 0)
                        {
                            if (c >= 0)
                            {
                                escribir.WriteLine("\nEcuacion a resolver: " + a + "x^2 +" + b + "x + " + c + " = 0");
                            }
                            else
                            {
                                escribir.WriteLine("\nEcuacion a resolver:  " + a + "x^2 +" + b + "x " + c + " = 0");
                            }
                        }
                        else
                        {
                            if (c >= 0)
                            {
                                escribir.WriteLine("\nEcuacion a resolver:  " + a + "x^2 " + b + "x + " + c + " = 0");
                            }
                            else
                            {
                                escribir.WriteLine("\nEcuacion a resolver:  " + a + "x^2 " + b + "x " + c + " = 0");
                            }
                        }
                        escribir.WriteLine("\n====================================================================");
                        if (disc > 0.0)
                        {
                            x1 = ((-b + Math.Sqrt(disc)) / (2 * a));
                            x2 = ((-b - Math.Sqrt(disc)) / (2 * a));
                            escribir.WriteLine("\nLas 2 Raices son reales");
                            escribir.WriteLine("\nLos valores encontrados son:");
                            escribir.WriteLine("X1 = " + x1);
                            escribir.WriteLine("X2 = " + x2);
                        }
                        else if (disc == 0.0)
                        {
                            x1 = (-b) / (2 * a);
                            escribir.WriteLine("\nLas 2 Raices son reales e iguales");
                            escribir.WriteLine("\nLos valores encontrados son:");
                            escribir.WriteLine("X1 = " + x1);
                            escribir.WriteLine("X2 = " + x1);
                        }
                        else
                        {
                            x1 = (-b) / (2 * a);
                            rCompleja = Math.Sqrt((4 * a * c) - Math.Pow(b, 2)) / (2 * a);
                            escribir.WriteLine("\nLas 2 Raices son imaginarias");
                            escribir.WriteLine("\nLos valores encontrados son:");
                            escribir.WriteLine("X1 = " + x1 + "+" + rCompleja + "i");
                            escribir.WriteLine("X2 = " + x1 + "-" + rCompleja + "i");
                        }
                        //Y cerramos la escritura del archivo
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiamos los textbox y tambien dejamos los label en blancos
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            lblX1.Text = "";
            lblX2.Text = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {//Primero verificamos si no se ha dejado vacio los textbox 
            if ((string.IsNullOrEmpty(txtA.Text)) || (string.IsNullOrEmpty(txtB.Text)) || (string.IsNullOrEmpty(txtC.Text)))
            {//Si es asi, se mandara un mensaje de que no podemos dejar valores en blanco
                MessageBox.Show("No deje valores en blanco, Favor introduzca un valor", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//Si no es asi y tenemos valores en los 3 textbox
            else
            {
                //Declaramos cada variable y convertimos la informacion del texbox a double 
                a = Double.Parse(txtA.Text);
                b = Double.Parse(txtB.Text);
                c = Double.Parse(txtC.Text);

                if (a == 0)
                {
                    MessageBox.Show("Esta no es una ecuación cuadrática, el coeficiente a debe ser diferente de 0", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    disc = (Math.Pow(b, 2)) - (4 * a * c);

                    if (disc > 0.0)
                    {
                        x1 = ((-b + Math.Sqrt(disc)) / (2 * a));
                        x2 = ((-b - Math.Sqrt(disc)) / (2 * a));
                        lblX1.Text = x1.ToString();
                        lblX2.Text = x2.ToString();
                    }
                    else if (disc == 0.0)
                    {
                        x1 = (-b) / (2 * a);
                        lblX1.Text = x1.ToString();
                        lblX2.Text = x1.ToString();
                    }
                    else
                    {
                        x1 = (-b) / (2 * a);
                        rCompleja = Math.Sqrt((4 * a * c) - Math.Pow(b, 2)) / (2 * a);
                        lblX1.Text = x1.ToString() + "+" + rCompleja.ToString() + "i";
                        lblX2.Text = x1.ToString() + "-" + rCompleja.ToString() + "i";
                    }
                }
            }
        }
    }
}
