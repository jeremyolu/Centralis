using Centralis.Data.Records;

namespace Centralis.Data.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatientRecords();
        Task<IEnumerable<Address>> GetPatientAddresses(long? patientId);
    }
}
