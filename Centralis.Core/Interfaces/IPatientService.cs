using Centralis.Core.Models;

namespace Centralis.Core.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientData>> GetPatients();
    }
}
