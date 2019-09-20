using Repository;

namespace Service
{
    internal class BaseService
    {
        /// <summary>
        /// Book Repository
        /// </summary>
        protected ISqlBookRepository SqlRepository { get; private set; }

        /// <summary>
        /// KotlinLang Repository
        /// </summary>
        protected IKotlinLangRepository KotlinLangRepository { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sqlRepository">Sql Repository</param>
        /// /// <param name="kotlinLangRepository">KotlinLang Repository</param>
        public BaseService(ISqlBookRepository sqlRepository, IKotlinLangRepository kotlinLangRepository)
        {
            SqlRepository = sqlRepository;
            KotlinLangRepository = kotlinLangRepository;
        }
    }
}
