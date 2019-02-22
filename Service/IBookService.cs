using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookIntegration>> GetBooks();

        BookDTO GetBookById(int id);

        BookDTO PostBook(BookRequest book);
    }
}
