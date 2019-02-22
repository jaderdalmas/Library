using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookIntegration>> GetBooks();

        Task<BookDTO> GetBookById(int id);

        Task<BookDTO> PostBook(BookRequest book);
    }
}
