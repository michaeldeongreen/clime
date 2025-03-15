namespace clistub.Common
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Extension method to convert nullable string to string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static string NullToString(this string? value)
        {
            return value == null ? "" : value.ToString();
        }
    }
}
