using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Library.ViewModel; 

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();

            // definindo o contexto de dados da tela (todos os bindings no XAML vão procurar suas propriedades dentro do objeto BooksViewModel)
            DataContext = new BooksViewModel();
        }
    }
}
