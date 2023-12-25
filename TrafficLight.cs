using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLight
{
    public partial class TrafficLight : Form
    {
        private PanelSemaforo panelSemaforo;
        private PanelSemaforo soportePanel1;
        private PanelSemaforo soportePanel2;
        private PanelSemaforo soportePanel3;
        private PanelSemaforo panelTemporizador;
        private Label labelTemporizador;
        private PictureBox pictureBoxRojo;
        private PictureBox pictureBoxNaranja;
        private PictureBox pictureBoxVerde;
        private Timer timer;
        private int tiempoRestante;

        public TrafficLight()
        {
            InitializeComponent();
            InitializeSemaforo();
            InitializeTimer();
        }

        private void InitializeSemaforo()
        {
            this.ClientSize = new Size(300, 300);
            this.Text = "TrafficLight";
            //this.FormBorderStyle = FormBorderStyle.None;

            panelSemaforo = new PanelSemaforo();
            panelSemaforo.Size = new Size(100, 250);
            panelSemaforo.Location = new Point(100, 25);
            panelSemaforo.BackColor = Color.FromArgb(136, 135, 135);
            panelSemaforo.BorderStyle = BorderStyle.Fixed3D;
            panelSemaforo.Padding = new Padding(10);
            panelSemaforo.Region = GetRoundedRegion(panelSemaforo.Width, panelSemaforo.Height);

            soportePanel1 = new PanelSemaforo();
            soportePanel1.Size = new Size(30, 30);
            soportePanel1.Location = new Point(30, 200);
            soportePanel1.BackColor = Color.FromArgb(136, 135, 135);
            soportePanel1.BorderStyle = BorderStyle.Fixed3D;
            soportePanel1.Padding = new Padding(10);
            soportePanel1.Region = GetRoundedRegion(panelSemaforo.Width, panelSemaforo.Height);

            soportePanel2 = new PanelSemaforo();
            soportePanel2.Size = new Size(30, 110);
            soportePanel2.Location = new Point(30, 200);
            soportePanel2.BackColor = Color.FromArgb(136, 135, 135);
            soportePanel2.BorderStyle = BorderStyle.Fixed3D;
            soportePanel2.Padding = new Padding(10);
            soportePanel2.Region = GetRoundedRegion(panelSemaforo.Width, panelSemaforo.Height);

            soportePanel3 = new PanelSemaforo();
            soportePanel3.Size = new Size(100, 30);
            soportePanel3.Location = new Point(30, 200);
            soportePanel3.BackColor = Color.FromArgb(136, 135, 135);
            soportePanel3.BorderStyle = BorderStyle.Fixed3D; // Sin borde del panel
            soportePanel3.Padding = new Padding(10);
            soportePanel3.Region = GetRoundedRegion(panelSemaforo.Width, panelSemaforo.Height);

            pictureBoxRojo = CreateLight(Color.Red);
            pictureBoxNaranja = CreateLight(Color.Orange);
            pictureBoxVerde = CreateLight(Color.Green);
            pictureBoxRojo.Location = new Point(20, 20);
            pictureBoxNaranja.Location = new Point(20, 95);
            pictureBoxVerde.Location = new Point(20, 170);
            panelSemaforo.Controls.Add(pictureBoxRojo);
            panelSemaforo.Controls.Add(pictureBoxNaranja);
            panelSemaforo.Controls.Add(pictureBoxVerde);

            panelTemporizador = new PanelSemaforo();
            panelTemporizador.Size = new Size(80, 80);
            panelTemporizador.Location = new Point(6, 180);
            panelTemporizador.BackColor = Color.Black;
            panelTemporizador.BorderStyle = BorderStyle.Fixed3D;
            panelTemporizador.Padding = new Padding(10);
            panelTemporizador.Region = GetRoundedRegion(panelTemporizador.Width, panelTemporizador.Height);

            labelTemporizador = new Label();
            labelTemporizador.Size = new Size(80, 80);
            labelTemporizador.Text = "";
            labelTemporizador.Font = new Font("DS-Digital", 40, FontStyle.Bold);
            labelTemporizador.ForeColor = Color.White;
            labelTemporizador.TextAlign = ContentAlignment.MiddleCenter;

            panelTemporizador.Controls.Add(labelTemporizador);
            this.Controls.Add(panelSemaforo);
            this.Controls.Add(panelTemporizador);
            this.Controls.Add(soportePanel1);
            this.Controls.Add(soportePanel2);
            this.Controls.Add(soportePanel3);
        }

        private PictureBox CreateLight(Color color)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(60, 60);
            pictureBox.BackColor = color;
            pictureBox.BorderStyle = BorderStyle.None;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Region = GetRoundedRegion(pictureBox.Width, pictureBox.Height);

            return pictureBox;
        }

        private Region GetRoundedRegion(int width, int height)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;

            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90); // Esquina superior izquierda
            path.AddLine(radius, 0, width - radius, 0); // Borde superior
            path.AddArc(width - radius * 2, 0, radius * 2, radius * 2, 270, 90); // Esquina superior derecha
            path.AddLine(width, radius, width, height - radius); // Borde derecho
            path.AddArc(width - radius * 2, height - radius * 2, radius * 2, radius * 2, 0, 90); // Esquina inferior derecha
            path.AddLine(width - radius, height, radius, height); // Borde inferior
            path.AddArc(0, height - radius * 2, radius * 2, radius * 2, 90, 90); // Esquina inferior izquierda
            path.AddLine(0, height - radius, 0, radius); // Borde izquierdo

            Region roundedRegion = new Region(path);
            return roundedRegion;
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            tiempoRestante = 25;
            labelTemporizador.Text = tiempoRestante.ToString();
            DefinirColoresIniciales();
            timer.Start();
        }

        private void DefinirColoresIniciales()
        {
            pictureBoxRojo.BackColor = Color.Red;
            pictureBoxNaranja.BackColor = Color.DarkGray;
            pictureBoxVerde.BackColor = Color.DarkGray;

            labelTemporizador.ForeColor = Color.Red;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tiempoRestante--;

            labelTemporizador.Text = tiempoRestante.ToString();

            if (tiempoRestante <= 0)
            {
                CambiarLuzSemaforo();
            }
        }

        private void CambiarLuzSemaforo()
        {
            if (pictureBoxRojo.BackColor == Color.Red
                && pictureBoxNaranja.BackColor == Color.DarkGray
                && pictureBoxVerde.BackColor == Color.DarkGray)
            {
                tiempoRestante = 2;

                labelTemporizador.Text = tiempoRestante.ToString();
                labelTemporizador.ForeColor = Color.Orange;

                pictureBoxRojo.BackColor = Color.Red;
                pictureBoxNaranja.BackColor = Color.Orange;
                pictureBoxVerde.BackColor = Color.DarkGray;
            }
            else if (pictureBoxRojo.BackColor == Color.Red
                && pictureBoxNaranja.BackColor == Color.Orange
                && pictureBoxVerde.BackColor == Color.DarkGray)
            {
                tiempoRestante = 30;

                labelTemporizador.Text = tiempoRestante.ToString();
                labelTemporizador.ForeColor = Color.Green;

                pictureBoxRojo.BackColor = Color.DarkGray;
                pictureBoxNaranja.BackColor = Color.DarkGray;
                pictureBoxVerde.BackColor = Color.Green;
            }
            else if (pictureBoxRojo.BackColor == Color.DarkGray
                && pictureBoxNaranja.BackColor == Color.DarkGray
                && pictureBoxVerde.BackColor == Color.Green)
            {
                tiempoRestante = 2;

                labelTemporizador.Text = tiempoRestante.ToString();
                labelTemporizador.ForeColor = Color.Orange;

                pictureBoxRojo.BackColor = Color.DarkGray;
                pictureBoxNaranja.BackColor = Color.Orange;
                pictureBoxVerde.BackColor = Color.DarkGray;
            }
            else if (pictureBoxRojo.BackColor == Color.DarkGray
                && pictureBoxNaranja.BackColor == Color.Orange
                && pictureBoxVerde.BackColor == Color.DarkGray)
            {
                tiempoRestante = 25;

                labelTemporizador.Text = tiempoRestante.ToString();
                labelTemporizador.ForeColor = Color.Red;

                pictureBoxRojo.BackColor = Color.Red;
                pictureBoxNaranja.BackColor = Color.DarkGray;
                pictureBoxVerde.BackColor = Color.DarkGray;
            }
        }
    }

    public class PanelSemaforo : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}