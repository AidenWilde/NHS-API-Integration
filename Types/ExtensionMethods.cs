public static class ExtensionMethods
{
    public static bool IsNullOrEmpty(this string value)
    {
        return value == null || value.Length == 0;
    }

    public static bool IsNullOrEmpty<T>(this List<T> value)
    {
        return value == null || value.Count() == 0;
    }
}