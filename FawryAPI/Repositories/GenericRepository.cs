
namespace FawryAPI.Repositories
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly ApplicationContext _ApplicationContext;

        public GenericRepository(ApplicationContext applicationContext)
        {
            _ApplicationContext = applicationContext;
        }
        public List<T> GetAll()
        {
            return _ApplicationContext.Set<T>().ToList();
        }
    }
}
