using System;
using System.Text.RegularExpressions;

namespace MyFlat.Common
{
    public static class BitrixSessionRetriever
    {
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
