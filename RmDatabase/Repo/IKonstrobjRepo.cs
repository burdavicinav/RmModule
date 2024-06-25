using RmDatabase.Entities;
using System.Collections.Generic;

namespace RmDatabase.Repo
{
    /// <summary>
    /// Репозиторий Konstrobj
    /// </summary>
    public interface IKonstrobjRepo
    {
        /// <summary>
        /// Поиск по UnvCode.
        /// </summary>
        /// <param name="id">UnvCode</param>
        /// <returns>Конструкторский элемент</returns>
        Konstrobj GetById(int id);

        /// <summary>
        /// Получение списка КД.
        /// </summary>
        /// <returns>Список КД</returns>
        IList<Konstrobj> GetList();

        /// <summary>
        /// Создание КД
        /// </summary>
        /// <param name="obj">КД</param>
        void Create(Konstrobj obj);

        /// <summary>
        /// Обновление КД
        /// </summary>
        /// <param name="obj">КД</param>
        void Update(Konstrobj obj);

        /// <summary>
        /// Удаление КД
        /// </summary>
        /// <param name="obj">КД</param>
        void Delete(Konstrobj obj);
    }
}
