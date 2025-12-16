// Esse arquivo inicializa a janela principal e permite que o usuário arraste a aplicação clicando e segurando em qualquer espaço

using System.Windows;
using System.Windows.Input;
using Library.ViewModel;

namespace Library
{
    public partial class MainWindow : Window
    {
        // CONSTRUTOR 

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BooksViewModel();
        }

        // MÉTODO

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}