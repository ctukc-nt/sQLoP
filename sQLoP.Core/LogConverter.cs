using System;

namespace sQLoP.Core
{
    public class LogConverter : ILogConverter
    {
        public AccessToResource ParseLogRecord(string lineLog)
        {
            var access = new AccessToResource();

            var word = GetFirstWord(lineLog);
            access.SetDateTimeFromUnix(word);
            access.Time = access.Time.ToLocalTime();


            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.SetElapsedFromStr(word);

            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.RemoteHost = word;

            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.CodeStatus = word;

            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.Bytes = Convert.ToUInt32(word);

            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.Method = word;

            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.URL = word;

            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.Rfc931 = word;

            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.PeerStatusHost = word;

            lineLog = lineLog.Substring(word.Length).Trim();

            word = GetFirstWord(lineLog);
            access.Type = word;

            return access;

        }

        private string GetFirstWord(string str)
        {
            var i = 0;
            var res = string.Empty;

            while (i < str.Length && !char.IsWhiteSpace(str[i]))
            {
                res += str[i];
                i++;
            }

            return res;
        }
    }
}