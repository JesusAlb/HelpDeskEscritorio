using HelpDeskEscritorio.AccionesBD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelpDeskEscritorio
{
    /// <summary>
    /// Lógica de interacción para principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private NotifyIcon nIcon;
        private bool conexion = true;
        private int contador;

        public Principal()
        {
            InitializeComponent();
            lbelNombre.Content = dbhelp.usuario.nomCompleto;
            this.manejadorNotifyIcon();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (dbhelp.usuario.username != null && conexion == true)
            {
                if (dbhelp.usuario.tipoUsuario == 0)
                {
                    int num = accionesBD.numero_de_incidentes_abiertos().Value;
                    if (num == -1)
                    {
                        conexion = false;
                        num = contador;
                    }
                    if (num != contador)
                    {
                        contador = num;
                        if (num > 0)
                        {
                            txtNumero_Incidentes.Foreground = new SolidColorBrush(Colors.Red);
                            txtNumero_Incidentes.Text = "" + num;
                            if (WindowState == WindowState.Minimized)
                            {
                                this.Show();
                            }
                            System.Windows.MessageBox.Show("Hay " + num + " incidente(s) sin responder", "ATENCIÓN", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.btnIncidentes.Focus();
                        }
                        else
                        {
                            txtNumero_Incidentes.Foreground = new SolidColorBrush(Colors.Green);
                            txtNumero_Incidentes.Text = "" + num;
                        }
                    }
                }
            }
        }

        private void manejadorNotifyIcon()
        {
            try
            {
                this.nIcon = new NotifyIcon();
                this.nIcon.BalloonTipText = "La Aplicación se encuentra ejecutando";
                this.nIcon.BalloonTipTitle = "Help desk - Esperando solicitudes";
                this.nIcon.Text = "Presione para Mostrar";
                this.nIcon.Icon = new Icon("./imca.ico");
                this.nIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                this.nIcon.Click += new EventHandler(iconoNotificacion_Click);
                System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();
                System.Windows.Forms.MenuItem item1 = new System.Windows.Forms.MenuItem("Mostrar aplicación");
                item1.Click += new EventHandler(item1_Click);
                System.Windows.Forms.MenuItem item2 = new System.Windows.Forms.MenuItem("Mostrar incidentes");
                item2.Click += new EventHandler(item2_Click);
                System.Windows.Forms.MenuItem item3 = new System.Windows.Forms.MenuItem("Mostrar eventos");
                item3.Click += new EventHandler(item3_Click);
                System.Windows.Forms.MenuItem item4 = new System.Windows.Forms.MenuItem("Cerrar");
                item4.Click += new EventHandler(item4_Click);
                menu.MenuItems.Add(item1);
                menu.MenuItems.Add(item2);
                menu.MenuItems.Add(item3);
                menu.MenuItems.Add(item4);
                this.nIcon.ContextMenu = menu;
            }
            catch
            {

            }
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("¿Desea mantener la aplicación en ejecución?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                this.nIcon = null;
                this.Close();
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Minimized;
            }
        }

        private void minButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnEventos_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://localhost:1698/autologin.aspx?usuario=" + dbhelp.usuario.username + "&password=" + dbhelp.usuario.password + "&peticion=1");
        }

        private void btnIncidentes_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://localhost:1698/autologin.aspx?usuario=" + dbhelp.usuario.username + "&password=" + dbhelp.usuario.password + "&peticion=0");
        }

        private void iconoNotificacion_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = System.Windows.WindowState.Normal;
        }

        void item4_Click(object sender, EventArgs e)
        {
            this.nIcon = null;
            this.Close();
        }

        void item3_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost:1698/autologin.aspx?usuario=" + dbhelp.usuario.username + "&password=" + dbhelp.usuario.password + "&peticion=1");
        }

        void item2_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost:1698/autologin.aspx?usuario=" + dbhelp.usuario.username + "&password=" + dbhelp.usuario.password + "&peticion=0");
        }

        void item1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = System.Windows.WindowState.Normal;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (this.nIcon != null)
                    this.nIcon.ShowBalloonTip(2000);
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            VerificarIcono();
        }

        private void VerificarIcono()
        {
            MostrarIcono(!IsVisible);
        }

        private void MostrarIcono(bool mostrar)
        {
            if (this.nIcon != null)
                this.nIcon.Visible = mostrar;
        }
    }
}
