namespace oop_backend.Models.Utils
{
    /// <summary>
    /// Класс генератора id
    /// </summary>
    public class IdGenerator
    {
        /// <summary>
        /// Статический счетчик
        /// </summary>
        private static int _id;

        /// <summary>
        /// Получить id
        /// </summary>
        /// <returns>id</returns>
        public int GetId()
        {
            _id++;
            return _id;
        }
    }
}
