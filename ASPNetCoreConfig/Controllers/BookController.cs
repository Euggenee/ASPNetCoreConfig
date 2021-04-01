using BussinessLayer.BookService;
using BussinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreConfig.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]

        public ActionResult<BookDto> Getbooks()
        {
            var books = _bookService.GetBooks();

            if (books != null)
            {
                return Ok(books);
            
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("add-book")]
        public ActionResult AddBook( BookDto bookDto)
        {
            var isSucsess = _bookService.AddBook(bookDto);
            if (isSucsess) 
            {
                return Ok();
            }
            return BadRequest();
           
        }

    }
}
