namespace FawryAPI.interfaces
{
    public interface IGeneric<T> where T : class
    {
        List<T> GetAll();
    }
}
