namespace CursoLinqPlatzi
{
    public class LinqQueries
    {
        private List<Book> booksCollection = [];

        public LinqQueries()
        {
            using StreamReader reader = new("books.json");

            string json = reader.ReadToEnd();
            booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        }

        public IEnumerable<Book> GetAllCollection()
        {
            return booksCollection;
        }

        public IEnumerable<Book> BooksBefore2000()
        {
            //ExtensionMethod
            //return booksCollection.Where(x => x.PublishedDate.Year > 2000);

            //QueryExpression
            return from books in booksCollection
                   where books.PublishedDate.Year > 2000
                   select books;
        }

        public IEnumerable<Book> BooksFiltered()
        {
            return from books in booksCollection
                   where books.PageCount > 250 &&
                         books.Title.Contains("in Action")
                   select books;
        }
    }
}