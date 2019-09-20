using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Repository
{
    internal class BaseRepository
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        protected string Cnn { get; private set; }

        /// <summary>
        /// KotlinLang Site
        /// </summary>
        protected string KotlinLangSite { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sqlRepository">Configuration</param>
        public BaseRepository(IConfiguration configuration)
        {
            Cnn = configuration["ConnectionString:SqlServer"];
            KotlinLangSite = configuration["ConnectionString:KotlinLangSite"];
        }

        /// <summary>
        /// Get a new sql connection
        /// </summary>
        /// <returns>Sql connection</returns>
        protected SqlConnection GetConnection
        {
            get
            {
                var cnn = new SqlConnection(Cnn);
                cnn.Open();

                return cnn;
            }
        }
    }
}
