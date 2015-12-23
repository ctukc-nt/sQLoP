namespace sQLoP.Core
{
    public interface ILogConverter
    {
        AccessToResource ParseLogRecord(string result);
    }
}