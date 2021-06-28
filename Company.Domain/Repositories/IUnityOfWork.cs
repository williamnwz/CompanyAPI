using System.Threading.Tasks;

namespace Company.Domain.Repositories
{
    public interface IUnityOfWork
    {

        Task Commit();
        Task RollBack();
    }
}
