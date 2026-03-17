using System;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

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
                var pattern = "\"DEBT_END\" {0,}: {0,}\"-?[0-9,.]+\"";
                var match = Regex.Match(html, pattern);
                if (!match.Success)
                    return false;

                var strings = match.Value.Split('"');
                result = decimal.Parse(strings[3], CultureInfo.InvariantCulture);
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
                // Double or single quotas in substring "bitrix_sessid":"2ef02a737a8389eca16e2a164cbe0241"
                const string pattern = @"['""]bitrix_sessid['""]\s*:\s*['""]([^'"")]+)['""]";
                Match match = Regex.Match(html, pattern, RegexOptions.IgnoreCase);
                if (match.Success && match.Groups.Count > 1)
                    result = match.Groups[1].Value;
            }
            catch
            {
                return false;
            }

            return !string.IsNullOrWhiteSpace(result);
        }
    }
}
