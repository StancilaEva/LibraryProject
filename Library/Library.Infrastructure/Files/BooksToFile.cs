using Library.Application.utils;
using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
     public class BooksToFile
    {
        IBookRepository bookRepository;
        public BooksToFile(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void WriteBooksToFile()
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "LibraryFolder");
            Directory.CreateDirectory(folderPath);
            string filesPath = Path.Combine(folderPath, "BookFile.csv");
            FileStream fileStream = File.Create(filesPath);
            using(StreamWriter writer = new StreamWriter(fileStream))
            {
               List<Book> books = bookRepository.GetAllBooks();
               foreach(Book book in books)
                {
                    writer.WriteLine(WriteBook(book));
                }
            }
        }

        public List<Book> RestoreBooksFromFile()
        {
            List<Book> books = new List<Book>();
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "LibraryFolder");
            string filesPath = Path.Combine(folderPath, "BookFile.csv");
            FileStream fileStream = File.OpenRead(filesPath);
            using(StreamReader reader = new StreamReader(fileStream))
            {
                while (true){
                    string line = reader.ReadLine();
                    if (line == null) break;
                    else
                    {
                        Book book = ReadBook(line);
                        books.Add(book);
                    }
                }
            }
            return books;
        }

        private Book ReadBook(string? line)
        {
            string[] stringArray = line.Split(',');
            Book book = new Book(stringArray[0], stringArray[1], stringArray[2], GenreConverter.FromString(stringArray[3]));
            return book;
        }

        private string WriteBook(Book book)
        {
            return $"{book.Id},{book.Title},{book.Author},{GenreConverter.FromEnum(book.Genre)}";
        }
    }
}
