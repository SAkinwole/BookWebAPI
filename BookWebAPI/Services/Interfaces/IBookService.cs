using BookWebAPI.DTOs;
using BookWebAPI.Entities;

namespace BookWebAPI.Services.Interfaces;

public interface IBookService
{
    public IEnumerable<Book> GetAllBooks();
    public Book GetById(long id);
    public void AddBook(CreateBookRequestDto requestDto);
}
