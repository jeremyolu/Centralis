using Centralis.Data.Records;

namespace Centralis.Data.Interfaces
{
    public interface IDataRepository
    {
        Task<IEnumerable<Hospital>> GetHospitalsRecords();
        Task<Hospital?> GetHospitalRecord(long? hopsitalId);
    }
}
