using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Timer timerNormal = new Timer();
        private Timer timerDanger = new Timer();
        private Timer timerWarning = new Timer();
        private int tiempoRestante;

        public TrafficLight()
        {
            InitializeComponent();
            InitializeSemaforo();
            DefinirColoresIniciales();
            AutomaticMode();
        }

        private void MostrarMensaje(string mensaje)
        {
            Task.Run(() =>
            {
                MessageBox.Show(mensaje);
            });
        }

        private void AutomaticMode()
        {
            PararTemporizadores();
            if (DateTime.Now.Hour > 22)
            {
                InitializeWarningMode();
                //MostrarMensaje("La hora es mayor a 22hs. Se inicializa el modo 'Warning'");
            }
            else if (DateTime.Now.Hour > 0 && DateTime.Now.Hour <= 5)
            {
                InitializeDangerMode();
                //MostrarMensaje("La hora es mayor a 0hs y menor a 5hs. Se inicializa el modo 'Danger'");
            }
            else
            {
                InitializeNormalMode();
                //MostrarMensaje("La hora es mayor a 5hs y menor a 22hs. Se inicializa el modo 'Normal'");
            }
        }

        private void DefinirColoresIniciales()
        {
            pictureBoxRojo.BackColor = Color.DarkGray;
            pictureBoxNaranja.BackColor = Color.DarkGray;
            pictureBoxVerde.BackColor = Color.DarkGray;
            labelTemporizador.Text = "";
            labelTemporizador.ForeColor = Color.DarkGray;
        }

        private void PararTemporizadores()
        {
            timerNormal.Stop();
            timerDanger.Stop();
            timerWarning.Stop();

            // Desvincular todos los eventos
            timerNormal.Tick -= Timer_Tick;
            timerDanger.Tick -= Timer_Tick_Danger;
            timerWarning.Tick -= Timer_Tick_Warning;
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
            labelTemporizador.Font = new Font("DS-Digital", 35, FontStyle.Bold);
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

        private void InitializeNormalMode()
        {
            timerNormal.Tick -= Timer_Tick; // Desvincula cualquier suscriptor existente
            timerNormal.Interval = 1000;
            timerNormal.Tick += Timer_Tick; // Asocia el evento
            tiempoRestante = 25;
            labelTemporizador.Text = tiempoRestante.ToString();
            DefinirColoresInicialesNormal();
            timerNormal.Start();
        }

        private void DefinirColoresInicialesNormal()
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
                CambiarLuzSemaforoNormal();
            }
        }

        private void CambiarLuzSemaforoNormal()
        {
            if (DateTime.Now.Hour > 22)
            {
                PararTemporizadores();
                InitializeWarningMode();
                MostrarMensaje("La hora es mayor a 22hs. Se inicializa el modo 'Warning'");
            }
            else if (DateTime.Now.Hour > 0 && DateTime.Now.Hour <= 5)
            {
                PararTemporizadores();
                InitializeDangerMode();
                MostrarMensaje("La hora es mayor a 0hs y menor a 5hs. Se inicializa el modo 'Danger'");
            }
            else
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

        private void peligroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PararTemporizadores();
            InitializeDangerMode();
        }

        private void precaucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PararTemporizadores();
            InitializeWarningMode();
        }

        private void modoNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PararTemporizadores();
            InitializeNormalMode();
        }

        private void InitializeDangerMode()
        {
            timerDanger.Tick -= Timer_Tick_Danger; // Desvincula cualquier suscriptor existente
            timerDanger.Interval = 1000;
            timerDanger.Tick += Timer_Tick_Danger; // Asocia el evento
            tiempoRestante = 1;
            labelTemporizador.Text = "Ø";
            DefinirColoresInicialesDanger();
            timerDanger.Start();
        }

        private void DefinirColoresInicialesDanger()
        {
            pictureBoxRojo.BackColor = Color.Red;
            pictureBoxNaranja.BackColor = Color.DarkGray;
            pictureBoxVerde.BackColor = Color.DarkGray;
            labelTemporizador.ForeColor = Color.Red;
        }

        private void Timer_Tick_Danger(object sender, EventArgs e)
        {
            tiempoRestante--;

            labelTemporizador.Text = "";

            if (tiempoRestante <= 0)
            {
                CambiarLuzSemaforoDanger();
            }
        }

        private void CambiarLuzSemaforoDanger()
        {
            if (DateTime.Now.Hour > 22)
            {
                PararTemporizadores();
                InitializeWarningMode();
                MostrarMensaje("La hora es mayor a 22hs. Se inicializa el modo 'Warning'");

            }
            else if (DateTime.Now.Hour > 5 && DateTime.Now.Hour <= 22)
            {
                PararTemporizadores();
                InitializeNormalMode();
                MostrarMensaje("La hora es mayor a 5hs y menor a 22hs. Se inicializa el modo 'Normal'");
            }
            else
            {
                if (pictureBoxRojo.BackColor == Color.Red)
                {
                    tiempoRestante = 1;
                    pictureBoxRojo.BackColor = Color.DarkGray;
                }
                else
                {
                    tiempoRestante = 1;
                    pictureBoxRojo.BackColor = Color.Red;
                    labelTemporizador.Text = "Ø";
                }
            }
        }

        private void InitializeWarningMode()
        {
            timerWarning.Tick -= Timer_Tick_Warning; // Desvincula cualquier suscriptor existente
            timerWarning.Interval = 1000;
            timerWarning.Tick += Timer_Tick_Warning; // Asocia el evento
            tiempoRestante = 1;
            labelTemporizador.Text = "⚠";
            DefinirColoresInicialesWarning();
            timerWarning.Start();
        }

        private void DefinirColoresInicialesWarning()
        {
            pictureBoxRojo.BackColor = Color.DarkGray;
            pictureBoxNaranja.BackColor = Color.Orange;
            pictureBoxVerde.BackColor = Color.DarkGray;
            labelTemporizador.ForeColor = Color.Orange;
        }

        private void Timer_Tick_Warning(object sender, EventArgs e)
        {
            tiempoRestante--;

            labelTemporizador.Text = "";

            if (tiempoRestante <= 0)
            {
                CambiarLuzSemaforoWarning();
            }
        }

        private void CambiarLuzSemaforoWarning()
        {
            if (DateTime.Now.Hour > 0 && DateTime.Now.Hour <= 5)
            {
                PararTemporizadores();
                InitializeDangerMode();
                MostrarMensaje("La hora es mayor a 0hs y menor a 5hs. Se inicializa el modo 'Danger'");
            }
            else if (DateTime.Now.Hour > 5 && DateTime.Now.Hour <= 22)
            {
                PararTemporizadores();
                InitializeNormalMode();
                MostrarMensaje("La hora es mayor a 5hs y menor a 22hs. Se inicializa el modo 'Normal'");
            }
            else
            {
                if (pictureBoxNaranja.BackColor == Color.Orange)
                {
                    tiempoRestante = 1;
                    pictureBoxNaranja.BackColor = Color.DarkGray;
                }
                else
                {
                    tiempoRestante = 1;
                    pictureBoxNaranja.BackColor = Color.Orange;
                    labelTemporizador.Text = "⚠";
                }
            }
        }

        private void modoAutomáticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutomaticMode();
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