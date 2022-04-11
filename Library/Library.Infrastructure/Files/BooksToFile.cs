using Library.Application.utils;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
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
        public async void WriteBooksToFile()
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "LibraryFolder");
            Directory.CreateDirectory(folderPath);
            string filesPath = Path.Combine(folderPath, "BookFile.csv");
            FileStream fileStream = File.Create(filesPath);
            using(StreamWriter writer = new StreamWriter(fileStream))
            {
               List<ComicBook> books = await bookRepository.GetAllBooksAsync();
               foreach(ComicBook book in books)
                {
                    writer.WriteLine(WriteBook(book));
                }
            }
        }

        public List<ComicBook> RestoreBooksFromFile()
        {
            List<ComicBook> books = new List<ComicBook>();
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
                        ComicBook book = ReadBook(line);
                        books.Add(book);
                    }
                }
            }
            return books;
        }

        private ComicBook ReadBook(string? line)
        {
            //string[] stringArray = line.Split(',');
            //ComicBook book = new ComicBook(Int32.Parse(stringArray[0]), stringArray[1],stringArray[2], GenreConverter.FromString(stringArray[3]),Int32.Parse(stringArray[4]));
            //return book;
            throw new NotImplementedException();
        }

        private string WriteBook(ComicBook book)
        {
            return $"{book.Id},{book.Title},{book.Publisher},{GenreConverter.FromEnum(book.Genre)},{book.IssueNumber}";
        }
    }
}
