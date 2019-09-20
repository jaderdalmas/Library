using Api;
using Model;
using System.Diagnostics.CodeAnalysis;
using Tests.Services;
using Xunit;

namespace UnitTest.Service
{
    [ExcludeFromCodeCoverage]
    public class BookServiceTest : BaseServiceTest, IClassFixture<ServiceWebApplicationFactory<Startup>>
    {
        public BookServiceTest(ServiceWebApplicationFactory<Startup> factory) : base(factory) { }

        [Fact]
        public void GetBookById1()
        {
            var result = GetBookService.GetBookById(1).Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void GetBook()
        {
            var result = GetBookService.GetBooks().Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void PostBook()
        {
            var book = new BookRequest()
            {
                Title = "Book title example",
                Description = "Book description example",
                ISBN = "9781617293290",
                Language = "BR"
            };

            var result = GetBookService.PostBook(book).Result;

            Assert.NotNull(result);
        }
    }
}
