// Essa classe fica responsável por indicar o que será considerado como Livro no projeto, contendo: Id, Title, Author, Category, Thumbnail, YearPublished, NumberOfPages

namespace Library.Models
{
    public class Books
    {
        // PROPRIEDADES
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public string? Thumbnail { get; set; }
        public int YearPublished { get; set; }
        public int NumberOfPages { get; set; }
    }
}