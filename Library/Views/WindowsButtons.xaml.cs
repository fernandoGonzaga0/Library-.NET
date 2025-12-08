using System.Windows;
using System.Windows.Controls;

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for WindowsButtons.xaml
    /// </summary>
    public partial class WindowsButtons : UserControl
    {
        public WindowsButtons()
        {
            InitializeComponent();
        }

        /*
        Adicionando funcionalidade nos botões. Será necessário chamar a janela por extenso, visto que o userControl não consegue se fechar. 
        */
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            // minimizando a janela
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e) 
        { 
            var window = Application.Current.MainWindow; 
            if (window.WindowState == WindowState.Normal) 
            { 
                window.WindowState = WindowState.Maximized; 
            } 
            else 
            { 
                window.WindowState = WindowState.Normal; 
            } 
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // fechando a janela atual
            Window.GetWindow(this)?.Close();
        }
    }
}