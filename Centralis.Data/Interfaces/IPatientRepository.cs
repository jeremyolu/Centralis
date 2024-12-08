using Centralis.Data.Records;

namespace Centralis.Data.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient?> GetPatientRecord(long? patientId);
        Task<IEnumerable<Patient>> GetPatientRecords();
        Task<IEnumerable<Address>> GetPatientAddresses(long? patientId);
    }
}
