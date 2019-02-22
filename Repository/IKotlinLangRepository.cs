using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IKotlinLangRepository
    {
        /// <summary>
        /// Get Books in Kotling Site
        /// </summary>
        /// <returns>List of Books</returns>
        Task<IEnumerable<BookIntegration>> GetBooks();

        /// <summary>
        /// Get ISBN by Url
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>ISBN as Long</returns>
        Task<long> GetISBN(string url);
    }
}
