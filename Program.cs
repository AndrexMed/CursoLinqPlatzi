using CursoLinqPlatzi;

LinqQueries linqQueries = new();
void PrintValues(IEnumerable<Book> books)
{
    Console.WriteLine("{0, -60}, {1, 15}, {2, 15}\n", "Title", "N. Pages", "Date Post");
    foreach (var item in books)
    {
        Console.WriteLine("{0, -60}, {1, 15}, {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void PrintValuesGroup(IEnumerable<IGrouping<int, Book>> booksListGroup)
{
    foreach (var grupo in booksListGroup)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha Publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate);
        }
    }
}

//Get All
//PrintValues(linqQueries.GetAllCollection());

//Libros despues del 2000
//PrintValues(linqQueries.BooksBefore2000());

//Books Filtered
//PrintValues(linqQueries.BooksFiltered());

//All books have status 
//Console.WriteLine($"All books have status: {linqQueries.AllBooksHaveStatus()}");

//Algun libro fue publicado en 2005? 
//Console.WriteLine($"One book publish in 2005: {linqQueries.OneBookPublishIn2005()}");

//Libros que contengan python
//PrintValues(linqQueries.BooksOfPython());

//Libros de Java ORder by title
//PrintValues(linqQueries.BooksJavaOrderByTitle());

//books pagecount > 450 desc
//PrintValues(linqQueries.BooksPageCountDesc());

//Three books of java 
//PrintValues(linqQueries.ThreeBooksJava());

//
//PrintValues(linqQueries.TercerYCuartoDeMasDe400Pag());

//Operador Sum
//Console.WriteLine($"Sum: {linqQueries.MethodSum()}");

//Operador Aggregate
//Console.WriteLine(linqQueries.MethodAggregate());

//Promedio
//Console.WriteLine(linqQueries.Promedio());

//Metodo GroupBy - Libros Publicados a partir del 2000 agrupados.

PrintValuesGroup(linqQueries.MethodGroupBy());