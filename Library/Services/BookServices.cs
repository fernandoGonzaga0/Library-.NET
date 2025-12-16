// Esse será o módulo responsável somente pela leitura do CSV, converter cada linha em um objeto Livro, devolver uma lista de Livro pronta para ser usada em ViewModel.

using System.IO; // permite manipular arquivos e caminhos
using Library.Models;

namespace BookServiceNamespace
{
    public class BookService
    {
        // PROPRIEDADES

        private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "Data", "books_cleaned.csv"); // fazendo com que o programa procure o arquivo books.csv * para fazer com que o arquivo seja encontrado, clicar com o botão direito o csv e seguir Properties -> Copy to Output Directory -> Copy if newer

        public List<Books> LoadBooks() // método que será chamado pelo ViewModel posteriormente
        {
            var books = new List<Books>(); // lista vazia por enquanto, será preenchida com os livros lidos do CSV

            var rows = File.ReadAllLines(_filePath); // esse comando abre o arquivo CSV, lê todas as rows e retorna um array de strings

            for (int i = 1; i < rows.Length; i++) // criando a iteração para obter cada linha, começando por 1 para não ler o cabeçalho
            {
                var columns = rows[i].Split(';'); // separando as rows por ;

                if (columns.Length != 7) continue; // se tiver menos ou mais que 7 colunas, pula o livro e descarta

                // validando os int 
                if (!int.TryParse(columns[0], out var id)) continue;
                if (!int.TryParse(columns[5], out var year)) continue;
                if (!int.TryParse(columns[6], out var pages)) continue;

                // validando campos obrigatórios 
                var title = columns[1];
                var author = columns[2];
                var category = columns[3];
                var thumbnail = columns[4];
                if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(category) ||
                string.IsNullOrWhiteSpace(thumbnail))
                continue;

                // selecionando apenas as colunas que desejo
                var book = new Books 
                {
                    /*
                        0 -> id
                        1 -> /
                        2 -> title
                        3 -> /
                        4 -> author
                        5 -> category
                        6 -> thumbnail
                        7 -> /
                        8 -> published_year
                        9 -> /
                        10 -> number_of_pages
                        11 -> /
                    
                    */

                    Id = id, // id
                    Title = title, // title
                    Author = author, // author
                    Category = category, // category
                    Thumbnail = thumbnail, // thumbnail
                    YearPublished = year, // published_year
                    NumberOfPages = pages
                };

                // adicionando cada livro na lista livros
                books.Add(book);
            }
            return books;
        }
    }
}