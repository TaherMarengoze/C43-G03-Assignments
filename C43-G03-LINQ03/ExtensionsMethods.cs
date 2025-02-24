namespace C43_G03_LINQ03;

public static class ExtensionMethods
{
    public static void PrintList<T>(this IEnumerable<T> list, bool indexed = false)
    {
        int i = 0;

        foreach (var item in list)
        {
            Console.WriteLine($"{(indexed ? $" {++i,+3}. " : " - ")}{item}");
        }
    }

    public static void PrintList<T>(this IEnumerable<T> list, Func<T, string> printingFormat)
    {
        foreach (var item in list)
        {
            Console.WriteLine(printingFormat.Invoke(item));
        }
    }

    public static void PrintListInline<T>(this IEnumerable<T> list,
                                          string delimiter = ", ",
                                          string prefix = "[ ",
                                          string suffix = " ]")
    {
        Console.WriteLine($"{prefix}{string.Join(delimiter, list)}{suffix}");
    }
}