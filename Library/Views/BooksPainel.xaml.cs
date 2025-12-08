using Library.ViewModel;
using System.Windows.Controls;


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
