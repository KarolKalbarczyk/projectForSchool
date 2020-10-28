using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_pl.Synchronization
{
    public interface ISynchronizationService
    {
        Task AddToErp(int productId, IEnumerable<ErpType> erps);
        Task Synchronize(List<ErpType> erps);
        IEnumerable<SynchronizationModel> GetSynchronizations();
    }
}