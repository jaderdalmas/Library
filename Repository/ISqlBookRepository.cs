using Model;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISqlBookRepository
    {
        /// <summary>
        /// Get Book By Id
        /// </summary>
        /// <param name="Id">Book id</param>
        /// <returns>Book DTO</returns>
        Task<BookDto> GetBook(int Id);

        /// <summary>
        /// Post Book as Requested
        /// </summary>
        /// <param name="book">Request Book</param>
        /// <returns>Book id</returns>
        Task<int> PostBook(BookRequest book);
    }
}
