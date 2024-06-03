using System;

namespace FakeReader.Services
{
    public class ScanDataService : IScanDataService
    {
        private int _currentId = 0;
        private readonly Dictionary<int, DocumentReaderSecurity> _scanDataStore = new Dictionary<int, DocumentReaderSecurity>();
        private static readonly Random _random = new Random();

        private static readonly List<string> FirstNames = new List<string>
    {
        "John", "Jane", "Alex", "Emily", "Chris", "Katie", "Michael", "Sarah", "David", "Laura"
    };

        private static readonly List<string> LastNames = new List<string>
    {
        "Doe", "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez"
    };

        private static readonly List<string> Genders = new List<string>
    {
        "M", "F"
    };

        public int CreateNewScanData()
        {
            var scanId = Interlocked.Increment(ref _currentId);
            var firstName = FirstNames[_random.Next(FirstNames.Count)];
            var lastName = LastNames[_random.Next(LastNames.Count)];
            var gender = Genders[_random.Next(Genders.Count)];
            var birthDate = GenerateRandomBirthDate();
            var idNumber = GenerateRandomIDNumber();
            var expiryDate = GenerateRandomExpiryDate();
            var issueDate = expiryDate.AddYears(-10);

            _scanDataStore[scanId] = new DocumentReaderSecurity
            {
                Code = "0",
                Data = new DocumentReaderSecurity.DocumentReaderSecurityResultDataModel
                {
                    _DateOfScan = DateTime.Now,
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    BirthDate = birthDate.ToString("MM/dd/yyyy"),
                    IDNumber = idNumber,
                    ExpiryDate = expiryDate.ToString("MM/dd/yyyy"),
                    IssueDate = issueDate.ToString("MM/dd/yyyy"),
                    Nationality = "GBR"
                }
            };

            return scanId;
        }

        public DocumentReaderSecurity GetScanData(int id)
        {
            _scanDataStore.TryGetValue(id, out var scanData);
            return scanData;
        }

        private DateTime GenerateRandomBirthDate()
        {
            // Ensure the birth date makes the person at least 18 years old
            int startYear = DateTime.Now.Year - 100; // oldest 100 years old
            int endYear = DateTime.Now.Year - 18;    // at least 18 years old
            int year = _random.Next(startYear, endYear);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateTime(year, month, day);
        }

        private string GenerateRandomIDNumber()
        {
            return _random.Next(10000000, 100000000).ToString("D8");
        }

        private DateTime GenerateRandomExpiryDate()
        {
            // Random expiry date between 1 to 10 years from now
            int year = DateTime.Now.Year + _random.Next(1, 11);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateTime(year, month, day);
        }
    }
}
