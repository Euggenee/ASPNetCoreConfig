using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.BookService
{
   public interface IBookService
    {
        public List<BookDto> GetBooks();
        public bool AddBook(BookDto bookDto);
    }
}
