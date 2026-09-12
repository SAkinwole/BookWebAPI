using BookWebAPI.Entities;

namespace BookWebAPI.Repositories;

public interface IBookRepository
{
    public ICollection<Book> GetAll();
    public Book Get(long Id);
    public void Add(Book book);
}
