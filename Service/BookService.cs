using Model;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class BookService : BaseService, IBookService
    {
        public BookService(ISqlBookRepository sqlRepository, IKotlinLangRepository kotlinLangRepository) : base(sqlRepository, kotlinLangRepository) { }

        public async Task<IEnumerable<BookIntegration>> GetBooks()
        {
            return await KotlinLangRepository.GetBooks();
        }

        public BookDTO GetBookById(int id)
        {
            return null;
        }

        public BookDTO PostBook(BookRequest book)
        {
            return null;
        }
    }
}
