using Centralis.Data.Records;

namespace Centralis.Core.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<Hospital>> GetHospitals();
        Task<Hospital> GetHospital(long? id);
    }
}
