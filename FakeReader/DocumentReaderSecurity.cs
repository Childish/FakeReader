namespace FakeReader
{
    /// <summary>
    /// This is the model that returns from Document Reader when a security check HAS been performed.
    /// </summary>
    public class DocumentReaderSecurity
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public DocumentReaderSecurityResultDataModel? Data { get; set; } = new DocumentReaderSecurityResultDataModel();

        public class DocumentReaderSecurityResultDataModel
        {
            public DateTime _DateOfScan { get; set; }
            public string _DocumentSide { get; set; }
            public string _DocumentSubtype { get; set; }
            public string _DocumentType { get; set; }
            public string FullName { get; set; }
            public string? FirstName { get; set; }
            public string FirstNameShort { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string BirthDate { get; set; }
            public string PlaceOfBirth { get; set; }
            public string IDNumber { get; set; }
            public string ExpiryDate { get; set; }
            public string IssueDate { get; set; }
            public string Restrictions { get; set; }
            public string CountryShort { get; set; }
            public string ISO_A2 { get; set; }
            public string ISO_A3 { get; set; }
            public string Country { get; set; }
            public string CountryName_EN { get; set; }
            public string CountryName_FR { get; set; }
            public string CountryName_HR { get; set; }
            public string Nationality { get; set; }
            public string NationalityISO_A2 { get; set; }
            public string NationalityISO_A3 { get; set; }
            public string Nationality_EN { get; set; }
            public string Nationality2 { get; set; }
            public string ImageFace { get; set; }
            public string ImageDocumentFront { get; set; }
            public string IsBiometric { get; set; }
        }
    }
}
