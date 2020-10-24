using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laberinto
{
    public partial class Form1 : Form
    {
        int[,] laberinto = new int[10, 10];
        string a = "";
        string inicio = "00";
        string fin = "99";
        string posicion_actual = "";
        Queue<string> cola = new Queue<string>();
        Stack<string> pila = new Stack<string>();
        List<string> Camino = new List<string>();





        public Form1()
        {
            InitializeComponent();
            

            

            
            
            
        }

        public void reinicio_laberinto()
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var peso = rand.Next(1, 11);
                    if (peso > 3)
                    {
                        laberinto[i, j] = 1;
                    }
                    else
                    {
                        laberinto[i, j] = 0;
                    }

                    a += laberinto[i, j] + ",";

                }
                System.Console.WriteLine(a);
                a = "";
            }

            laberinto[0, 0] = laberinto[9, 9] = 1;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            reinicio_laberinto();
            SolidBrush rojo = new SolidBrush(Color.Red);
            SolidBrush verde = new SolidBrush(Color.Green);

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (laberinto[i, j].Equals(1))
                    {
                        Rectangle rect= new Rectangle(j*20, i*20, 20, 20);
                        e.Graphics.FillRectangle(verde, rect);
                    }
                    else
                    {
                        Rectangle rect=new Rectangle(j*20, i*20, 20, 20);
                        e.Graphics.FillRectangle(rojo, rect);
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

        }

        public string Izquierda_cola(string casilla)
        {
            int fila = int.Parse(casilla[0].ToString());
            int columna = int.Parse(casilla[1].ToString());
            int aux = fila - 1;
            string paso = aux.ToString() + columna.ToString();
            try
            {
                if (laberinto[aux, columna].Equals(1))
                {
                    if (Camino.Contains(paso))
                    {
                        return "sin camino";

                    }
                    else
                    {
                        if(fin.Equals(paso))
                        {
                            cola.Enqueue(paso);
                            label2.Text = "Solucion encontrada";
                            return "Solucion encontrada";
                        }

                        Camino.Add(paso);
                        cola.Enqueue(paso);
                        return "nodo añadido";
                        
                    }


                }
                else
                {
                    return "sin camino";
                }
            }
            catch
            {
                return "sin camino";
            }
        }


        public string Derecha_cola(string casilla)
        {
            int fila = int.Parse(casilla[0].ToString());
            int columna = int.Parse(casilla[1].ToString());
            int aux = fila + 1;
            string paso = aux.ToString() + columna.ToString();
            try
            {
                if (laberinto[aux, columna].Equals(1))
                {
                    if (Camino.Contains(paso))
                    {
                        return "sin camino";

                    }
                    else
                    {
                        if (fin.Equals(paso))
                        {
                            cola.Enqueue(paso);
                            label2.Text = "Solucion encontrada";
                            return "Solucion encontrada";

                        }

                        Camino.Add(paso);
                        cola.Enqueue(paso);
                        return "nodo añadido";

                    }


                }
                else
                {
                    return "sin camino";
                }
            }
            catch
            {
                return "sin camino";
            }
        }

        public string Abajo_cola(string casilla)
        {
            int fila = int.Parse(casilla[0].ToString());
            int columna = int.Parse(casilla[1].ToString());
            int aux = columna + 1;
            string paso = fila.ToString() + aux.ToString();
            try
            {
                if (laberinto[fila, aux].Equals(1))
                {
                    if (Camino.Contains(paso))
                    {
                        return "sin camino";

                    }
                    else
                    {
                        if (fin.Equals(paso))
                        {
                            cola.Enqueue(paso);
                            label2.Text = "Solucion encontrada";
                            return "Solucion encontrada";
                        }

                        Camino.Add(paso);
                        cola.Enqueue(paso);
                        return "nodo añadido";

                    }


                }
                else
                {
                    return "sin camino";
                }
            }
            catch
            {
                return "sin camino";
            }
        }


        public string Arriba_cola(string casilla)
        {
            int fila = int.Parse(casilla[0].ToString());
            int columna = int.Parse(casilla[1].ToString());
            int aux = columna - 1;
            string paso = fila.ToString() + aux.ToString();
            try
            {
                if (laberinto[fila, aux].Equals(1))
                {
                    if (Camino.Contains(paso))
                    {
                        return "sin camino";

                    }
                    else
                    {
                        if (fin.Equals(paso))
                        {
                            cola.Enqueue(paso);
                            label2.Text = "Solucion encontrada";
                            return "Solucion encontrada";
                        }

                        Camino.Add(paso);
                        cola.Enqueue(paso);
                        return "nodo añadido";

                    }


                }
                else
                {
                    return "sin camino";
                }
            }
            catch
            {
                return "sin camino";
            }
        }



        public string Izquierda_pila(string casilla)
        {
            int fila = int.Parse(casilla[0].ToString());
            int columna = int.Parse(casilla[1].ToString());
            int aux = fila - 1;
            string paso = aux.ToString() + columna.ToString();
            try
            {
                if (laberinto[aux, columna].Equals(1))
                {
                    if (Camino.Contains(paso))
                    {
                        return "sin camino";

                    }
                    else
                    {
                        if (fin.Equals(paso))
                        {
                            pila.Push(paso);
                            label3.Text = "Solucion encontrada";
                            return "Solucion encontrada";
                        }

                        Camino.Add(paso);
                        pila.Push(paso);
                        return "nodo añadido";

                    }


                }
                else
                {
                    return "sin camino";
                }
            }
            catch
            {
                return "sin camino";
            }
        }


        public string Derecha_pila(string casilla)
        {
            int fila = int.Parse(casilla[0].ToString());
            int columna = int.Parse(casilla[1].ToString());
            int aux = fila + 1;
            string paso = aux.ToString() + columna.ToString();
            try
            {
                if (laberinto[aux, columna].Equals(1))
                {
                    if (Camino.Contains(paso))
                    {
                        return "sin camino";

                    }
                    else
                    {
                        if (fin.Equals(paso))
                        {
                            pila.Push(paso);
                            label3.Text = "Solucion encontrada";
                            return "Solucion encontrada";

                        }

                        Camino.Add(paso);
                        pila.Push(paso);
                        return "nodo añadido";

                    }


                }
                else
                {
                    return "sin camino";
                }
            }
            catch
            {
                return "sin camino";
            }
        }

        public string Abajo_pila(string casilla)
        {
            int fila = int.Parse(casilla[0].ToString());
            int columna = int.Parse(casilla[1].ToString());
            int aux = columna + 1;
            string paso = fila.ToString() + aux.ToString();
            try
            {
                if (laberinto[fila, aux].Equals(1))
                {
                    if (Camino.Contains(paso))
                    {
                        return "sin camino";

                    }
                    else
                    {
                        if (fin.Equals(paso))
                        {
                            pila.Push(paso);
                            label3.Text = "Solucion encontrada";
                            return "Solucion encontrada";
                        }
                        Camino.Add(paso);
                        pila.Push(paso);
                        return "nodo añadido";

                    }


                }
                else
                {
                    return "sin camino";
                }
            }
            catch
            {
                return "sin camino";
            }
        }


        public string Arriba_pila(string casilla)
        {
            int fila = int.Parse(casilla[0].ToString());
            int columna = int.Parse(casilla[1].ToString());
            int aux = columna - 1;
            string paso = fila.ToString() + aux.ToString();
            try
            {
                if (laberinto[fila, aux].Equals(1))
                {
                    if (Camino.Contains(paso))
                    {
                        return "sin camino";

                    }
                    else
                    {
                        if (fin.Equals(paso))
                        {
                            pila.Push(paso);
                            label3.Text = "Solucion encontrada";
                            return "Solucion encontrada";
                        }
                        Camino.Add(paso);
                        pila.Push(paso);
                        return "nodo añadido";

                    }


                }
                else
                {
                    return "sin camino";
                }
            }
            catch
            {
                return "sin camino";
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            

            listBox1.Items.Clear();
           
            Camino.Clear();
            cola.Clear();
            
            cola.Enqueue(inicio);
            Camino.Add(inicio);
            
            inicio = "00";
            posicion_actual = "";

            Cola();

            listBox2.Items.Clear();
            Camino.Clear();
            pila.Clear();
            Camino.Add(inicio);
            pila.Push(inicio);
            inicio = "00";
            posicion_actual = "";

            Pila();

        }

        public void Cola()
        {
            string estado_actual;
            string ruta;
            while(cola.Count()>0)
            {
                ruta = "";
                foreach(string coordenada in cola)
                {
                    ruta += coordenada+",";
                }

                listBox1.Items.Add(ruta);
                
                estado_actual = "";
                estado_actual = cola.Dequeue();
                System.Console.WriteLine(estado_actual);
                if(Arriba_cola(estado_actual).Equals("Solucion encontrada"))
                {
                    ruta = "";
                    foreach (string coordenada in cola)
                    {
                        ruta += coordenada + ",";
                    }

                    listBox1.Items.Add(ruta);
                    break;

                }

                if (Abajo_cola(estado_actual).Equals("Solucion encontrada"))
                {
                    ruta = "";
                    foreach (string coordenada in cola)
                    {
                        ruta += coordenada + ",";
                    }

                    listBox1.Items.Add(ruta);
                    break;

                }

                if (Derecha_cola(estado_actual).Equals("Solucion encontrada"))
                {
                    ruta = "";
                    foreach (string coordenada in cola)
                    {
                        ruta += coordenada + ",";
                    }

                    listBox1.Items.Add(ruta);
                    break;

                }

                if (Izquierda_cola(estado_actual).Equals("Solucion encontrada"))
                {
                    ruta = "";
                    foreach (string coordenada in cola)
                    {
                        ruta += coordenada + ",";
                    }

                    listBox1.Items.Add(ruta);
                    break;

                }

                if (cola.Count().Equals(0))
                {

                    label2.Text = "Solucion no encontrada";
                }




            }

        }



        public void Pila()
        {
            string estado_actual;
            string ruta;
            while (pila.Count() > 0)
            {
                ruta = "";
                foreach (string coordenada in pila)
                {
                    ruta += coordenada + ",";
                }

                listBox2.Items.Add(ruta);

                estado_actual = "";
                estado_actual = pila.Pop();
                System.Console.WriteLine(estado_actual);
                if (Arriba_pila(estado_actual).Equals("Solucion encontrada"))
                {
                    ruta = "";
                    foreach (string coordenada in pila)
                    {
                        ruta += coordenada + ",";
                    }

                    listBox2.Items.Add(ruta);
                    break;

                }

                if (Abajo_pila(estado_actual).Equals("Solucion encontrada"))
                {
                    ruta = "";
                    foreach (string coordenada in pila)
                    {
                        ruta += coordenada + ",";
                    }

                    listBox2.Items.Add(ruta);
                    break;

                }

                if (Derecha_pila(estado_actual).Equals("Solucion encontrada"))
                {
                    ruta = "";
                    foreach (string coordenada in pila)
                    {
                        ruta += coordenada + ",";
                    }

                    listBox2.Items.Add(ruta);
                    break;

                }

                if (Izquierda_pila(estado_actual).Equals("Solucion encontrada"))
                {
                    ruta = "";
                    foreach (string coordenada in pila)
                    {
                        ruta += coordenada + ",";
                    }

                    listBox2.Items.Add(ruta);
                    break;

                }

                if (pila.Count().Equals(0))
                {

                    label3.Text = "Solucion no encontrada";
                }




            }

        }
    }
}
