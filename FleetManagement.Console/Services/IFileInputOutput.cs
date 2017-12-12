namespace FleetManagementConsole.Services
{
    public interface IFileInputOutput
    {
        string[] ReadLine(string filename);
        void WriteLine(string filename, string data);
    }
}