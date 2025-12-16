// Nesse arquivo controlaremos a rolagem infinita do user pela ScrollBar

using Library.ViewModel;
using System.Windows.Controls;

namespace Library.Views
{
    public partial class BooksPainel : UserControl
    {
        // CAMPOS

        private bool _isLoadingNextPage;

        // CONSTRUTORE

        public BooksPainel()
        {
            InitializeComponent();
        }

        // MÉTODO

        private void ListView_ScrollChanged(object sender, ScrollChangedEventArgs e) // configurando o comportamento da scrollbar em BooksPainel
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