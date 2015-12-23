using System;
using System.Globalization;

namespace sQLoP.Core
{
    public class AccessToResource
    {
        public DateTime Time { get; set; }

        public TimeSpan Elapsed { get; set; }

        public string RemoteHost { get; set; }

        public string CodeStatus { get; set; }

        public long Bytes  { get; set; }

        public string Method { get; set; }

        public string URL { get; set; }

        public string Rfc931 { get; set; }

        public string PeerStatusHost { get; set; }

        public string Type { get; set; }


        public void SetDateTimeFromUnix(double d)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Time = origin.AddSeconds(d);
        }

        public void SetDateTimeFromUnix(string d)
        {
            var curDemSep = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            d = d.Replace(".", curDemSep).Replace(",", curDemSep).Trim();

            SetDateTimeFromUnix(Convert.ToDouble(d));
        }

        public void SetElapsedFromStr(string d)
        {
            var curDemSep = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            d = d.Replace(".", curDemSep).Replace(",", curDemSep);

            Elapsed = TimeSpan.FromMilliseconds(Convert.ToDouble(d));
        }

        public override string ToString()
        {
            return $"{Time} {RemoteHost} {Bytes} {Method} {URL} {Type}";
        }
    }
}