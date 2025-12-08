using System.Collections.ObjectModel;
using Library.Models;
using BookServiceNamespace;

namespace Library.ViewModel;

public class BooksViewModel
{
    private readonly BookService _bookService;
    private List<Books> _allBooks;
    private int _currentIndex = 0;
    private const int PageSize = 10; // limite inicial

    public ObservableCollection<Books> BooksCollection { get; set; }
    public BooksViewModel()
    {
        _bookService = new BookService();
        _allBooks = _bookService.LoadBooks(); // carregando todos os livros
        BooksCollection = new ObservableCollection<Books>();

        LoadNextPage();
    }
    public void LoadNextPage()
    {
        var nextBooks = _allBooks.Skip(_currentIndex).Take(PageSize);
        foreach (var book in nextBooks)
        {
            BooksCollection.Add(book);
        }
        _currentIndex += PageSize;
    }
}