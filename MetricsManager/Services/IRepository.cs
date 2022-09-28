namespace MetricsManagers.Services
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получение данных за период
        /// </summary>
        /// <param name="timeFrom">Время начала периода</param>
        /// <param name="timeTo">Время окончания периода</param>
        /// <returns></returns>

        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void EnableAgentById(int id);
        void DisableAgentById(int id);

        IList<T> GetAll();
    }

}
