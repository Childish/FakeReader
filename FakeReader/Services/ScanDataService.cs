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
                    FirstName = "Jay",
                    LastName = "Sparks",
                    Gender = "M",
                    BirthDate = "11/08/1995",
                    IDNumber = "11111111",
                    ExpiryDate = "1/1/2025",
                    IssueDate = "1/1/2020",
                    Nationality_EN = "British, UK"
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
