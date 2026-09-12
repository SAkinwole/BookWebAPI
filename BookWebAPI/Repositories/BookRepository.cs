using BookWebAPI.Data;
using BookWebAPI.Entities;

namespace BookWebAPI.Repositories;

public class BookRepository(AppDbContext _dbContext) : IBookRepository
{
    public ICollection<Book> GetAll()
    {
        return _dbContext.Books.ToList();
    }

    public Book Get(long Id)
    {
        return _dbContext.Books.Where(x => x.Id == Id).FirstOrDefault();
    }

    public void Add(Book book)
    {
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
    }
}
