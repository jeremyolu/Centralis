using Centralis.Data.Extensions;
using Centralis.Data.Interfaces;
using Centralis.Data.Interfaces.Clients;
using Centralis.Data.Records;
using Microsoft.Data.SqlClient;

namespace Centralis.Data.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly IDbClient _dbClient;

        public DataRepository(IDbClient dbClient)
        {
            _dbClient = dbClient;
        }

        public async Task<Hospital?> GetHospitalRecord(long? hopsitalId)
        {
            var input = new Dictionary<string, object?>
            {
                { "HospitalId",  hopsitalId }
            };

            return await _dbClient.GetSingleAsync("SELECT * FROM Hospitals WHERE Id = @HospitalId", (reader) => SetHospitalData(reader), inputs: input);
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsRecords()
        {
            return await _dbClient.GetAsync("SELECT * FROM Hospitals", (reader) => SetHospitalData(reader));
        }

        private Hospital SetHospitalData(SqlDataReader reader)
        {
            return new Hospital
            {
                Id = reader.BigInt("Id"),
                Name = reader.String("Name"),
                AddressLine1 = reader.String("Name"),
                AddressLine2 = reader.String("AddressLine2"),
                PostalCode = reader.String("PostalCode"),
                City = reader.String("City"),
                Country = reader.String("Country")
            };
        }
    }
}
