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

        public async Task<BookDto> GetBookById(int id)
        {
            return await SqlRepository.GetBook(id);
        }

        public async Task<BookDto> PostBook(BookRequest book)
        {
            var response = book.GetBookDTO();
            response.ID = await SqlRepository.PostBook(book);

            return response;
        }
    }
}
