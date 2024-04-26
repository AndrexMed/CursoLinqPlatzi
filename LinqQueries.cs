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

        public bool AllBooksHaveStatus()
        {
            return booksCollection.All(x => x.Status != string.Empty);
        }

        public bool OneBookPublishIn2005()
        {
            //Si un item cumple la cond retorna true.
            return booksCollection.Any(x => x.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> BooksOfPython()
        {
            return booksCollection.Where(x => x.Categories.Contains("Python"));
        }

        public IEnumerable<Book> BooksJavaOrderByTitle()
        {
            return booksCollection.Where(x => x.Categories.Contains("Java")).OrderBy(x => x.Title);
        }

        public IEnumerable<Book> BooksPageCountDesc()
        {
            return booksCollection.Where(x => x.PageCount > 450).OrderByDescending(x => x.PageCount);
        }

        public IEnumerable<Book> ThreeBooksJava()
        {
            return booksCollection.Where(x => x.Categories.Contains("Java")).OrderByDescending(x => x.PublishedDate).Take(3);
        }

        public IEnumerable<Book> TercerYCuartoDeMasDe400Pag()
        {
            return booksCollection.Where(x => x.PageCount > 400).Take(4).Skip(2);
        }

        public int MethodSum()
        {
            return booksCollection.Where(x => x.PageCount >= 0 && x.PageCount <= 500).Sum(x => x.PageCount);
        }

        public string MethodAggregate()
        {
            return booksCollection.Where(x => x.PublishedDate.Year > 2015)
                .Aggregate("", (titulos, next) =>
                {
                    if (titulos != string.Empty)
                    {
                        titulos += " - " + next.Title;
                    }
                    else
                    {
                        titulos += next.Title;
                    }
                    return titulos;
                });
        }

        public double Promedio()
        {
            return booksCollection.Average(x => x.Title.Length);
        }

        public IEnumerable<IGrouping<int, Book>> MethodGroupBy()
        {
            return booksCollection.Where(x => x.PublishedDate.Year >= 2000).GroupBy(x => x.PublishedDate.Year);
        }

        public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
        {
            return booksCollection.ToLookup(x => x.Title[0], x => x);
        }
    }
}