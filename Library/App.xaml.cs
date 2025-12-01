using System.Configuration;
using System.Data;
using System.Windows;
using BookServiceNamespace;

namespace Library
{
    public partial class App: Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            // Continua com a inicialização da janela principal
            var mainWindow = new MainWindow();
            mainWindow.Show();

            base.OnStartup(e);

            var service = new BookService();

            var books = service.LoadBooks();

            var firstBook = books.FirstOrDefault();
            if (firstBook != null)
            {
                MessageBox.Show($"Title: {firstBook.Title}, Author: {firstBook.Author}");
            }
            else
            {
                MessageBox.Show("Vazio!");
            }

        }
    }
}