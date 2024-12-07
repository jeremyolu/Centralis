using Centralis.Core.Interfaces;
using Centralis.Core.Models;
using Centralis.Data.Interfaces;
using Centralis.Data.Records;

namespace Centralis.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<PatientData>> GetPatients()
        {
            var patients = new List<PatientData>();

            var records = await _patientRepository.GetPatientRecords();

            foreach (var record in records)
            {
                patients.Add(MapPatientData(record));
            }

            return patients;
        }

        private async Task<PatientData>? MapPatientData(Patient patient)
        {
            var addresses = await _patientRepository.GetPatientAddresses(patient.Id);

            if (patient != null)
            {
                return new PatientData
                {
                    MedicalNo = patient.Id,
                    Names = new Identifier
                    {
                        Title = patient.Title,
                        FirstName = patient.FirstName,
                        MiddleNames = patient.MiddleNames,
                        Surname = patient.Surname,
                        Fullname = $"{patient.FirstName} {patient.MiddleNames} {patient.Surname}",
                    },
                    Dob = patient.DateOfBirth!.Value.Date.ToString("dd/MM/yyyy"),
                    Age = CalculateAge(patient.DateOfBirth!.Value),
                    CountryOfBirth = patient.CountryOfBirth,
                    Sex = patient.Sex,
                    Gender = patient.Gender,
                    ContactDetails = new ContactDetail
                    {
                        Mobile = patient.Mobile,
                        Email = patient.Email
                    },
                    Addresses = addresses
                };
            }

            return null;
        }


        private int CalculateAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;

            if (DateTime.Now < dob.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
