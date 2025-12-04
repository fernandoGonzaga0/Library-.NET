using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.Views
{
    /// <summary>
    /// Interaction logic for BooksPainel.xaml
    /// </summary>
    public partial class BooksPainel : UserControl
    {
        public BooksPainel()
        {
            InitializeComponent();
        }

        private void ListView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = e.OriginalSource as ScrollViewer;

            // quando o user se aproxima do fim da fila, carrega mais livros
            if (scrollViewer.VerticalOffset >= scrollViewer.ScrollableHeight - 50)
            {
                var vm = DataContext as BooksViewModel;
                vm?.LoadNextPage();
            }
        }
    }
}
