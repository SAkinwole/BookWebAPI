using BookWebAPI.DTOs;
using BookWebAPI.Entities;
using BookWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IBookService _bookService) : ControllerBase
{

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _bookService.GetAllBooks();
        return Ok(result);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long Id)
    {
        var result = _bookService.GetById(Id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddBook(CreateBookRequestDto book)
    {
        _bookService.AddBook(book);
        return Ok();
    }
}
