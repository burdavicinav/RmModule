namespace RmDatabase
{
    /// <summary>
    /// Интерфейс для работы с БД.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Старт транзакции.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Коммит.
        /// </summary>
        void Commit();

        /// <summary>
        /// Откат.
        /// </summary>
        void Rollback();
    }
}