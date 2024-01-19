namespace FakeReader.Services
{
    public class ScanDataService : IScanDataService
    {
        private int _currentId = 0;
        private readonly Dictionary<int, DocumentReaderSecurity> _scanDataStore = new Dictionary<int, DocumentReaderSecurity>();

        public int CreateNewScanData()
        {
            var scanId = Interlocked.Increment(ref _currentId);
            _scanDataStore[scanId] = new DocumentReaderSecurity
            {
                Code = "0",
                Data = new DocumentReaderSecurity.DocumentReaderSecurityResultDataModel
                {
                    _DateOfScan = DateTime.Now,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = "M",
                    BirthDate = "01/01/1990",
                    IDNumber = "11111111",
                    ExpiryDate = "01/01/2025",
                    IssueDate = "01/01/2020",
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
    }
}
