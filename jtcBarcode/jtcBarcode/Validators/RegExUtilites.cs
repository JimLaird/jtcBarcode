using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;

namespace jtcBarcode
{
    class RegExUtilites
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                //  Normalise the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                //  Examines the domain part of the email address
                string DomainMapper(Match match)
                {
                    //  Use idnmapping class
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidUrl (string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            Uri uriResult;

            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
             

    }
}
