using Centralis.Core.Models;

namespace Centralis.Core.Interfaces
{
    public interface IPatientService
    {
        Task<PatientData?> GetPatient(long? patientId);
        Task<IEnumerable<PatientData>> GetPatients();
    }
}
