using Centralis.Data.Records;

namespace Centralis.Core.Models
{
    public class PatientData
    {
        public long? MedicalNo { get; set; }
        public Identifier? Identifiers { get; set; }
        public string Dob { get; set; }
        public int Age { get; set; }
        public string? CountryOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? Gender { get; set; }
        public int? EthnicGroup { get; set; }
        public ContactDetail? ContactDetails { get; set; }
        public IEnumerable<Address>? Addresses { get; set; }
    }
}
