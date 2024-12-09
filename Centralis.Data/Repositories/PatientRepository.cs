using Centralis.Data.Extensions;
using Centralis.Data.Interfaces;
using Centralis.Data.Interfaces.Clients;
using Centralis.Data.Records;
using Microsoft.Data.SqlClient;

namespace Centralis.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbClient _dbClient;

        public PatientRepository(IDbClient dbClient)
        {
            _dbClient = dbClient;
        }

        public async Task<Patient?> GetPatientRecord(long? patientId)
        {
            var input = new Dictionary<string, object?>
            {
                { "PatientId",  patientId }
            };

            return await _dbClient.GetSingleAsync("SELECT * FROM Patients wHERE Id = @PatientId", (reader) => SetPatientData(reader), inputs: input);
        }

        public async Task<IEnumerable<Patient>> GetPatientRecords()
        {
            return await _dbClient.GetAsync("SELECT * FROM Patients", (reader) => SetPatientData(reader));
        }

        public async Task<IEnumerable<Address>> GetPatientAddresses(long? patientId)
        {
            string sql = 
                "select a.AddressLine1, a.AddressLine2, a.PostalCode, a.City, a.Country " +
                "FROM Patients p " +
                "JOIN PatientAddresses pa ON p.Id = pa.PatientId " +
                "JOIN Addresses a ON pa.AddressId = a.Id " +
                "WHERE p.Id = @PatientId";

            var inputs = new Dictionary<string, object?>
            {
                { "PatientId", patientId },
            };

            var addresses = await _dbClient.GetAsync(sql, (reader) => new Address
            {
                AddressLine1 = reader.String("AddressLine1"),
                AddressLine2 = reader.String("AddressLine2"),
                PostalCode = reader.String("PostalCode"),
                City = reader.String("City"),
                Country = reader.String("Country")

            }, inputs: inputs);

            return addresses;
        }

        private Patient SetPatientData(SqlDataReader reader)
        {
            return new Patient
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
            };
        }
    }
}
