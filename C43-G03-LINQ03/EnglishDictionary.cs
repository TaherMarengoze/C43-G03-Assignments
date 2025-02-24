namespace C43_G03_LINQ03
{
    public static class EnglishDictionary
    {
        public static List<string> Words;

        static EnglishDictionary()
        {
            Words = [.. File.ReadAllLines("dictionary_english.txt")];
        }
    }
}
