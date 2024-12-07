using Centralis.Data.Extensions;
using Centralis.Data.Interfaces;
using Centralis.Data.Interfaces.Clients;
using Centralis.Data.Records;

namespace Centralis.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbClient _dbClient;

        public PatientRepository(IDbClient dbClient)
        {
            _dbClient = dbClient;
        }

        public async Task<IEnumerable<Patient>> GetPatientRecords()
        {
            var patients = await _dbClient.GetAsync("select * from patients", (reader) => new Patient 
            {
                Id = reader.BigInt("Id"),
                Title = reader.String("Title"),
                FirstName = reader.String("FirstName"),
                MiddleNames = reader.String("MiddleNames"),
                Surname = reader.String("Surname"),
                DateOfBirth = reader.DateTime("DateOfBirth"),
                CountryOfBirth = reader.String("CountryOfBirth"),
                Gender = reader.String("Gender"),
                Sex = reader.String("Sex"),
                EthnicGroup = reader.Int("EthnicGroup"),
                Mobile = reader.String("Mobile"),
                Email = reader.String("Email")
            });

            return patients;
        }

        public async Task<IEnumerable<Address>> GetPatientAddresses(long? patientId)
        {
            string sql = "";

            var inputs = new Dictionary<string, object?>
            {
                { "Id", patientId },
            };

            var addresses = await _dbClient.GetAsync(sql, (reader) => new Address
            {
                
            }, inputs: inputs);

            return addresses;
        }
    }
}
