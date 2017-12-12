using FleetManagementConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Tests.Mocks
{
    class ConsoleMock : IConsoleInputOutput
    {
        public string readLineReturn;
        public Action<string> writeAction;
        public Action<string> writeLineAction;

        public ConsoleMock()
        {

        }

        public ConsoleMock(string readLineReturn, Action<string> writeAction, Action<string> writeLineAction)
        {
            this.readLineReturn = readLineReturn;
            this.writeAction = writeAction;
            this.writeLineAction = writeLineAction;
        }

        public string ReadLine()
        {
            return readLineReturn;
        }

        public void Write(string str)
        {
        }

        public void WriteError(string str)
        {
        }

        public void WriteInfo(string str)
        {
        }

        public void WriteLine(string str)
        {
        }

        public void WriteSelected(string str)
        {
        }
    }
}
