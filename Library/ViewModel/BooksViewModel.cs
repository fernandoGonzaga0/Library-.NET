/*

Classe responsável por conectar a interface do usuário (XAML) com os dados dos livros. 

    Gerenciamento de Dados
        
        Carrega todos os livros do arquivo CSV através do BookService
        Mantém uma lista completa de todos os livros disponíveis
        Controla a exibição paginada dos livros (carregando em lotes para performance)

    Filtragem e Busca

        Implementa o sistema de busca em tempo real
        Filtra livros por título conforme o usuário digita
        Restaura a lista completa quando o campo de busca está vazio
        Ignora diferenças entre maiúsculas/minúsculas nas buscas

    Comunicação com a interface 

        Fornece dados para a ListView exibir os livros
        Notifica automaticamente a interface quando os dados mudam (via INotifyPropertyChanged)
        Disponibiliza o comando para o botão OK da busca

*/

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Models;
using BookServiceNamespace;
using System.Windows.Input;

namespace Library.ViewModel;

public class BooksViewModel : INotifyPropertyChanged
{
    // CAMPOS

    private readonly BookService _bookService;
    private List<Books> _allBooks; // lista que armazena todos os livros carregados pelo serviço BookService (serve como a fonte de dados principal e imutável na aplicação).
    private int _currentIndex = 0;
    private const int PageSize = 10; // limite inicial
    private string _searchText; // propriedade para filtragem de livros
    public ObservableCollection<Books> _filteredBooks;

    // CONSTRUTORES

    public BooksViewModel()
    {
        _bookService = new BookService();
        _allBooks = _bookService.LoadBooks(); // carregando todos os livros
        BooksCollection = new ObservableCollection<Books>();

        FilteredBooks = new ObservableCollection<Books>(_allBooks); // inicializando FilteredBooks com todos os livros
        
        SearchCommand = new RelayCommand(_ => FilterBooks()); // cria o comando de busca

        LoadNextPage();
    }

    // PROPRIEDADES

    public ICommand SearchCommand { get; }
    public event PropertyChangedEventHandler? PropertyChanged;
    public ObservableCollection<Books> BooksCollection { get; set; }

    // MÉTODOS

    public ObservableCollection<Books> FilteredBooks // método para filtrar os livros da coleção original _allBooks
    {
        get => _filteredBooks;
        set 
        {
            _filteredBooks = value;
            OnPropertyChanged();
        }
    }

    public string SearchText // método para obter o texto inserido no input a fim de usá-lo como busca
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged();

            
            if (_searchText.Length == 0) // filtrando automaticamente quando o input estiver vazio, com isso evitamos que o user tenha que apagar o input e clicar em enter
            {
            
            FilterBooks();
            }
        }
    }

    public void FilterBooks() // método para filtrar os livros conforme o que foi escrito no input
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            FilteredBooks = new ObservableCollection<Books>(_allBooks); // se estiver vazio, mostra todos os livros
        }
        else
        {
            var filtered = _allBooks.Where(book => book.Title != null && book.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
            FilteredBooks = new ObservableCollection<Books>(filtered);
        }
        OnPropertyChanged(nameof(FilteredBooks)); // notifica que a coleção foi atualizada
    }

    public void LoadNextPage() // método para carregar a próxima página na ListView
    {
        var nextBooks = _allBooks.Skip(_currentIndex).Take(PageSize);
        foreach (var book in nextBooks)
        {
            BooksCollection.Add(book);
        }
        _currentIndex += PageSize;
    }

    // EVENTOS

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // CLASSES

    public class RelayCommand : ICommand // criando uma implementação da interface ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object? parameter) => _execute(parameter);
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}