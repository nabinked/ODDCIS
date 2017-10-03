using System;

namespace ODDCIS.Common
{
    public static class Conversion
    {
        public static T ConvertTo<T, U>(U value) where U : IConvertible
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T ToEnum<T>(this string enumString) where T : struct
        {
            if (Enum.TryParse(enumString, out T result))
            {
                return result;
            }
            return result;
        }

        public static T ToEnum<T>(this int enumInt)
        {
            return (T)Enum.ToObject(typeof(T), enumInt);
        }
    }
}
