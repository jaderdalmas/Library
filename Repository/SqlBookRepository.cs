using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System.Data;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlBookRepository : BaseRepository, ISqlBookRepository
    {
        public SqlBookRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<BookDTO> GetBook(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32);

            return await GetConnection.ExecuteScalarAsync<BookDTO>("dbo.SpS_Book", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> PostBook(BookRequest book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Title", book.Title, DbType.String);
            parameters.Add("@Description", book.Description, DbType.String);
            parameters.Add("@ISBN", book.ISBN, DbType.Int64);
            parameters.Add("@Language", book.Language, DbType.String);

            var result = await GetConnection.ExecuteScalarAsync<ResultEntity>("dbo.SpI_Book", parameters, commandType: CommandType.StoredProcedure);

            return result.Result;
        }
    }
}
