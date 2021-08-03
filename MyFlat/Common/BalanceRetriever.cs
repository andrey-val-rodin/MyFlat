using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MyFlat.Common
{
    public static class BalanceRetriever
    {
        public static bool TryGetBalance(string html, out decimal result)
        {
            if (html == null)
                throw new ArgumentNullException(nameof(html));

            result = 0;
            try
            {
                var pattern = "\"DEBT_END\" {0,}: {0,}\"[0-9,.]+\"";
                var match = Regex.Match(html, pattern);
                if (!match.Success)
                    return false;

                pattern = "[0-9,.]+";
                match = Regex.Match(match.Value, pattern);
                if (!match.Success)
                    return false;

                result = decimal.Parse(match.Value, CultureInfo.InvariantCulture);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
