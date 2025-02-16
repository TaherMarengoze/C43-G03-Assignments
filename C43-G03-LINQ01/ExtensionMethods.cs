namespace C43_G03_LINQ01
{
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

        public static void PrintList<T>(this IEnumerable<T> list, Func<T,string> printingFormat)
        {
            foreach (var item in list)
            {
                Console.WriteLine(printingFormat.Invoke(item));
            }
        }
    }
}
