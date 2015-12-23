using System.Threading.Tasks;

namespace sQLoP.Core
{
    public interface ILogReader
    {
        string LogFile { get; set; }

        string ReadNextLineFromLog();

        Task<string> ReadNextLineFromLogAsync();
    }
}