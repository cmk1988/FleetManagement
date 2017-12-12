namespace FleetManagementConsole.Services
{
    public interface IConsoleInputOutput
    {
        void Write(string str);
        void WriteLine(string str);
        string ReadLine();
        void WriteError(string str);
        void WriteInfo(string str);
        void WriteSelected(string str);
    }
}