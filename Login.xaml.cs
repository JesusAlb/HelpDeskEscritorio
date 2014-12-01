using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelpDeskEscritorio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dbhelp.modelo.vt_usuarios.SingleOrDefault(a => a.id == 1);
        }


        private void txtContra_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtContra.Password))
            {
                txtContra.Foreground = Brushes.Gray;
                txtContra.Password = "Contraseña";
            }
        }

        private void txtUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Foreground = Brushes.Gray;
                txtUsuario.Text = "Usuario";
            }
        }

        private void txtUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Foreground == Brushes.Gray)
            {
                txtUsuario.Foreground = Brushes.Black;
                txtUsuario.Text = "";
            }
        }

        private void txtContra_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtContra.Foreground == Brushes.Gray)
            {
                txtContra.Foreground = Brushes.Black;
                txtContra.Password = "";
            }
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void minButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void txtUsuario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void Ingresar_Click(object sender, RoutedEventArgs e)
        {
            if (AccionesBD.accionesBD.validarUsuario(txtUsuario.Text, txtContra.Password))
            {
                Principal ventana = new Principal();
                this.Close();
                ventana.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña inválida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
