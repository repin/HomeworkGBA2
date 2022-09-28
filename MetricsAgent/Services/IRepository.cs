namespace MetricsAgent.Services
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получение данных за период
        /// </summary>
        /// <param name="timeFrom">Время начала периода</param>
        /// <param name="timeTo">Время окончания периода</param>
        /// <returns></returns>
        IList<T> GetByTimePeriod(TimeSpan timeFrom, TimeSpan timeTo);

        /// <summary>
        /// Получение всех данных
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

}
