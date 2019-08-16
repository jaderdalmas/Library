using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Service;
using UnitTest.Repository.MockTest;

namespace UnitTest.Service
{
    [TestClass]
    public class BookServiceTest
    {
        public BookService GetService
        {
            get
            {
                return new BookService(new SqlBookRepositoryMockTest(), new KotlinLangRepositoryMockTest());
            }
        }

        [TestMethod]
        public void GetBookById1()
        {
            var result = GetService.GetBookById(1).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBook()
        {
            var result = GetService.GetBooks().Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostBook()
        {
            var book = new BookRequest()
            {
                Title = "Book title example",
                Description = "Book description example",
                ISBN = "9781617293290",
                Language = "BR"
            };

            var result = GetService.PostBook(book).Result;

            Assert.IsNotNull(result);
        }
    }
}
