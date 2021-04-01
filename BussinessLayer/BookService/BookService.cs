using BussinessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer.BookService
{
    public class BookService : IBookService
    {

        private readonly IApplicationDbContext _dbContext;
        public BookService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddBook(BookDto bookDto)
        {
            if (bookDto != null)
            {
                var tempBook = new DataAccessLayer.Entities.Book
                {
                    Name = bookDto.Name,
                    Categories = new List<DataAccessLayer.Entities.Categorie>()     
                };

                foreach ( var Categorie in bookDto.CategoriesDtos ) 
                {
                    tempBook.Categories.Add(new DataAccessLayer.Entities.Categorie { 
                    
                     Name=Categorie.Name,
                     Genere=Categorie.Genere,
                       
                    });
                }
                _dbContext.Books.Add(tempBook);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<BookDto> GetBooks()
        {
            var books = _dbContext.Books.Include(p => p.Categories).ToList();

            
            if (books != null)
            {
                List<BookDto> tempBooks = new List<BookDto>();
                foreach (var book in books)
                {
                    var tempBook = new BookDto
                    {
                       Id = book.Id,
                       Name = book.Name,
                       CategoriesDtos = new List<CategoriesDto>()
                    };
                    foreach (var cat in book.Categories)
                    {
                        tempBook.CategoriesDtos.Add(new CategoriesDto {Name = cat.Name, Genere = cat.Genere});
                    }
                    tempBooks.Add(tempBook);

                }
                return tempBooks;
            }
            return null;
        }



    }
}
