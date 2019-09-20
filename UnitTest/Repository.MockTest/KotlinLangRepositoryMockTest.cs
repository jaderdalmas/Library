using Model;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTest.Repository.MockTest
{
    public class KotlinLangRepositoryMockTest : IKotlinLangRepository
    {
        public Task<IEnumerable<BookIntegration>> GetBooks() => Task.FromResult((IEnumerable<BookIntegration>)new List<BookIntegration>());

        public Task<string> GetISBN(string url) => Task.FromResult("");
    }
}
