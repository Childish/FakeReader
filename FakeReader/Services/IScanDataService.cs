namespace FakeReader.Services
{
    public interface IScanDataService
    {
        int CreateNewScanData();
        DocumentReaderSecurity GetScanData(int id);
    }
}
