using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MyFlat.Common
{
    public static class HtmlParser
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

        public static bool TryGetSessionId(string html, out string result)
        {
            if (html == null)
                throw new ArgumentNullException(nameof(html));

            result = null;
            try
            {
                var pattern = "'bitrix_sessid' {0,}: {0,}'.*'";
                var match = Regex.Match(html, pattern);
                if (!match.Success)
                    return false;

                var strings = match.Value.Split('\'');
                result = strings[3];
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
