namespace C43_G03_LINQ02;

public static class ConsoleFormatter
{
    public static void ColoredText(string value, ConsoleColor forecolor, bool underline = false, bool topline = false)
    {
        ConsoleColor restoreColor = Console.ForegroundColor;
        Console.ForegroundColor = forecolor;

        if (topline)
            Console.WriteLine("".PadRight(value.Length, '='));

        Console.WriteLine(value);

        if (underline)
            Console.WriteLine("".PadRight(value.Length, '='));

        Console.ForegroundColor = restoreColor;
    }

    public static void HRule(int length = 60, char chr = '=', bool noTopPadding = false, bool noBottomPadding = false)
    {
        if (!noTopPadding)
            Console.WriteLine();

        Console.WriteLine("".PadRight(length, chr));

        if (!noBottomPadding)
            Console.WriteLine();
    }

    public static void LineBreak(int count = 1)
    {
        Console.Write(new String('\n', count));
    }
}