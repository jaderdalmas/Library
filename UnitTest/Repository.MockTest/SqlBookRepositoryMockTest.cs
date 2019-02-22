using Model;
using Repository;
using System.Threading.Tasks;

namespace UnitTest.Repository.MockTest
{
    public class SqlBookRepositoryMockTest : ISqlBookRepository
    {
        public Task<BookDto> GetBook(int Id)
        {
            return Task.FromResult(new BookDto());
        }

        public Task<long> PostBook(BookRequest book)
        {
            return Task.FromResult((long)1);
        }
    }
}
