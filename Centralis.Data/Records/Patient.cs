namespace Centralis.Data.Records
{
    public class Patient
    {
        public long? Id { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleNames { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? CountryOfBirth { get; set; }
        public int? EthnicGroup { get; set; }
        public string? Sex { get; set; }
        public string? Gender { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
    }
}
