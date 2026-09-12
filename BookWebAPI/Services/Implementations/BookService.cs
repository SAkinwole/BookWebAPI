using BookWebAPI.DTOs;
using BookWebAPI.Entities;
using BookWebAPI.Repositories;
using BookWebAPI.Services.Interfaces;

namespace BookWebAPI.Services.Implementations;

public class BookService(IBookRepository _bookRepository) : IBookService
{
    public void AddBook(CreateBookRequestDto requestDto)
    {
        var book = new Book
        {
            Name = requestDto.Name,
            Description = requestDto.Description,
            Author = requestDto.Author
        };

        _bookRepository.Add(book);
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _bookRepository.GetAll();
    }

    public Book GetById(long id)
    {
        return _bookRepository.Get(id);
    }
}
