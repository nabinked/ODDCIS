using System;

namespace ODDCIS.Common.Extensions
{
    public static class UriExtensinos
    {
        public static bool EqualsFull(this Uri uri, Uri otherUri)
        {
            return Uri.Compare(uri, otherUri,
                UriComponents.Host | UriComponents.PathAndQuery | UriComponents.Fragment,
                     UriFormat.SafeUnescaped, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
