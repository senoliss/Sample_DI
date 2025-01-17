﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Mime;
using WebApplication2.Databases;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepository _bookDataBase;

        public BookController(IBooksRepository bookDataBase)
        {
            _bookDataBase = bookDataBase;
        }

        /// <summary>
        /// Grazina visus todo irasus
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [Produces(MediaTypeNames.Application.Json)]
        public IEnumerable<Book> GetAll()       // turetu grazinti IActionResult
        {
            var data = _bookDataBase.GetAll();
            return data;
        }

        /// <summary>
        /// Grazina todo itema pagal id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("single/{id}")]
        public Book GetSingleBook(int id)
        {
            var data = _bookDataBase.GetAll().Find(b => b.Id == id);
            return data;
        }

        [HttpGet("pagedlist/{pageNum}")]
        public IEnumerable<Book> GetPagedList(int pageNum, int pageSize)
        {
            var data = _bookDataBase.GetAll().Skip((pageNum - 1) * pageSize).Take(pageSize);
            return data;            
        }

        [HttpGet("sortedlist")]
        public IEnumerable<Book> GetSortedBookList()
        {
            var data = _bookDataBase.GetAll().OrderBy(b => b.Title);
            return data;
        }

        /// <summary>
        /// Iraso nauja irasa i duomenu baze ir issiuncia email
        /// </summary>
        /// <param name="book"></param>
        [HttpPost]
        public void CreateBook(Book book)
        {
            _bookDataBase.InsertBook(book);
        }

        [HttpPut]
        public void UpdateBook(Book book)
        {
            _bookDataBase.UpdateBook(book);
        }

        [HttpPut("updateTitle")]
        public void UpdateBookTitle(BookWithTitle book)
        {
            _bookDataBase.UpdateTitle(book.Id, book.Title);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id) 
        {
            _bookDataBase.RemoveBook(id);
        }
    }
}
