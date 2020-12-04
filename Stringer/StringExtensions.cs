using System;
using System.Linq;

namespace Stringer
{
    public static class StringExtensions
    {
        public static bool IsNull(this string str) => str is null;
        
        public static bool IsNotNull(this string str) => !IsNull(str);

        public static bool IsEmpty(this string str) => str == string.Empty;

        public static bool IsNotEmpty(this string str) => !IsEmpty(str);

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static bool IsNotNullOrEmpty(this string str) => !string.IsNullOrEmpty(str);

        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);
        
        public static bool IsNotNullOrWhiteSpace(this string str) => !string.IsNullOrWhiteSpace(str);

        public static bool Contain(this string str, string value) =>
            str.IsNullOrEmpty() || value.IsNullOrEmpty() ? false : str.Contains(value);

        public static bool NotContain(this string str, string value) => !Contain(str, value);

        public static bool In(this string str, string[] values, StringComparison stringComparison = StringComparison.Ordinal) => 
            str.IsNullOrEmpty() || values is null || values.Length == 0 ? false : values.Any(x => x.Equals(str, stringComparison));

        public static bool NotIn(this string str, string[] values, StringComparison stringComparison = StringComparison.Ordinal) =>
            !In(str, values, stringComparison);

        public static bool Equal(this string str, string value, StringComparison stringComparison = StringComparison.Ordinal) =>
            str.IsNullOrEmpty() || value.IsNullOrEmpty() ? false : str.Equals(value, stringComparison);

        public static bool NotEqual(this string str, string value, StringComparison stringComparison = StringComparison.Ordinal) =>
            !Equal(str, value, stringComparison);
    }
}
