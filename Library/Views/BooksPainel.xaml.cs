using Library.ViewModel;
using System.Windows.Controls;


namespace Library.Views
{
    /// <summary>
    /// Interaction logic for BooksPainel.xaml
    /// </summary>
    public partial class BooksPainel : UserControl
    {
        private bool _isLoadingNextPage;
        public BooksPainel()
        {
            InitializeComponent();
        }

        private void ListView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // reage apenas quando houver scroll para baixo
            if (e.VerticalChange <= 0) return;

            // quando estiver perto do fim, ajuste o thresold se necessário
            if (e.VerticalOffset + e.ViewportHeight >= e.ExtentHeight - 1)
            {
                if (_isLoadingNextPage) return;
                _isLoadingNextPage = true;

                if (DataContext is BooksViewModel vm)
                {
                    vm.LoadNextPage();
                }

                _isLoadingNextPage = false;
            }
        }
    }
}
