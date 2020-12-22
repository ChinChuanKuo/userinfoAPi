using System.Net;
using System.Collections.Generic;
using userinfoApi.App_Code;
using System.Text.RegularExpressions;

namespace userinfoApi.App_Code
{
    public class regulation
    {
        public bool regulationumber(int textlength, string text)
        {
            return text.Length != textlength || !new Regex("^[0-9]+$").IsMatch(text);
        }

        public bool regulationcard(int textlength, string text)
        {
            return text.Length != textlength || !new Regex("^[A-Z]{1}[0-9]{9}$").IsMatch(text);
        }

        public bool regulationphone(int textlength, string text)
        {
            return text.Length != textlength || !new Regex("^[0]{1}[9]{1}[0-9]{8}$").IsMatch(text);
        }
    }
}
