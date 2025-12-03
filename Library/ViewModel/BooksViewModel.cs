using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Library.Models;
using BookServiceNamespace;

namespace Library.ViewModel;

public class BooksViewModel
{
    private readonly BookService _bookService;
    private List<Books> _allBooks;
    private int _curentIndex = 0;
    private const int PageSize = 10;

    public ObservableCollection<Books> BooksCollection { get; set; }
    public BooksViewModel()
    {
        _bookService = new BookService();
        _allBooks = _bookService.LoadBooks(); // carregando todos os livros
        
        
        BooksCollection = new ObservableCollection<Books>(booksList);


    }
}