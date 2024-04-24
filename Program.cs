﻿using CursoLinqPlatzi;

LinqQueries linqQueries = new();
void PrintValues(IEnumerable<Book> books)
{
    Console.WriteLine("{0, -60}, {1, 15}, {2, 15}\n", "Title", "N. Pages", "Date Post");
    foreach (var item in books)
    {
        Console.WriteLine("{0, -60}, {1, 15}, {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

PrintValues(linqQueries.GetAllCollection());