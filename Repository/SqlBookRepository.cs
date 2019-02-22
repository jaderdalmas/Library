using Microsoft.Extensions.Configuration;
using System;

namespace Repository
{
    public class SqlBookRepository : BaseRepository, ISqlBookRepository
    {
        public SqlBookRepository(IConfiguration configuration) : base(configuration) { }
    }
}
