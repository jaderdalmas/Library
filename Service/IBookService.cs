using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookIntegration>> GetBooks();

        Task<BookDto> GetBookById(int id);

        Task<BookDto> PostBook(BookRequest book);
    }
}
