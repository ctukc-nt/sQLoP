using System.IO;
using System.Threading.Tasks;

namespace sQLoP.Core
{
    public class LogReader : ILogReader
    {
        private StreamReader _file;

        public string LogFile { get; set; }

        public string ReadNextLineFromLog()
        {
            if (_file == null)
                _file = File.OpenText(LogFile);

            var line = _file.ReadLine();

            return line;
        }

        public Task<string> ReadNextLineFromLogAsync()
        {
            if (_file == null)
                _file = File.OpenText(LogFile);

            return _file.ReadLineAsync();
        }
    }
}