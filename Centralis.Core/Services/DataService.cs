using Centralis.Core.Interfaces;
using Centralis.Data.Interfaces;
using Centralis.Data.Records;

namespace Centralis.Core.Services
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<IEnumerable<Hospital>> GetHospitals()
        {
            return await _dataRepository.GetHospitalsRecords();
        }

        public async Task<Hospital?> GetHospital(long? id)
        {
            var hospital = await _dataRepository.GetHospitalRecord(id);

            if (hospital == null)
            {
                return null;
            }

            return hospital;
        }
    }
}
