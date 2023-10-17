using CordycepsServices.Models;

namespace CordycepsServices.Services.InfectedService
{
    public interface IInfectedService
    {
        int GetInfectedCount();
        List<Infected> GetInfectedList();
        void IncreaseInfected();
    }
}
