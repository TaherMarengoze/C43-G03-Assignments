namespace C43_G03_ADV03;

/*
3.	We need to Implement the List methods from scratch with all overloads.
 ● Exist (No overload)
 ● Find (No overload)
 ● Find All (No overload)
 ● Find index (2 overloads)
 ● Find Last (No overload)
 ● Find Last Index (2 overloads)
 ● Foreach (No overload)
 ● TrueForAll (No overload)
*/

public static class ListMethods
{
    //●	Exist
    public static bool Exist<T>(List<T> list, T value)
    {
        foreach (var item in list)
        {
            if (Compare(value, item))
            {
                return true;
            }
        }

        return false;

    }

    //●	Find
    public static T? Find<T>(List<T> list, T value)
    {
        foreach (var item in list)
        {
            if (Compare(value, item))
            {
                return item;
            }
        }

        return default;
    }

    //●	Find All
    public static List<T>? FindAll<T>(List<T> list, T value)
    {
        List<T>? result = null;

        foreach (var item in list)
        {
            if (Compare(value, item))
            {
                result ??= [];
                result.Add(item);
            }
        }

        return result;
    }

    //●	Find index
    public static int FindIndex<T>(List<T> list, T value)
    {
        int index = -1;

        foreach (var item in list)
        {
            index++;

            if (Compare(value, item))
            {
                return index;
            }
        }

        return -1;
    }

    public static int FindIndex<T>(List<T> list, int startIndex, T value)
    {
        if (list.Count - 1 < startIndex)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = startIndex; i < list.Count; i++)
        {
            if (Compare(value, list[i]))
            {
                return i;
            }
        }

        return -1;
    }

    public static int FindIndex<T>(List<T> list, int startIndex, int count, T value)
    {
        if (list.Count -1  < startIndex || startIndex + count > list.Count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = startIndex; i < startIndex + count - 1; i++)
        {
            if (Compare(value, list[i]))
            {
                return i;
            }
        }

        return -1;
    }

    //●	Find Last
    public static T? FindLast<T>(List<T> list, T value)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (Compare(value, list[i]))
            {
                return list[i];
            }
        }

        return default;
    }

    //●	Find Last Index
    public static int FindLastIndex<T>(List<T> list, T value)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (Compare(value, list[i]))
            {
                return i;
            }
        }

        return -1;
    }

    public static int FindLastIndex<T>(List<T> list, int startIndex, T value)
    {
        if (startIndex < 0 || startIndex > list.Count - 1)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = startIndex; i >= 0; i--)
        {
            if (Compare(value, list[i]))
            {
                return i;
            }
        }

        return -1;
    }

    public static int FindLastIndex<T>(List<T> list, int startIndex, int count, T value)
    {
        if (count < 1)
        {
            throw new ArgumentException("The parameter {count} must be greater than Zero");
        }

        if (startIndex < 0 || startIndex > list.Count - 1 || startIndex - count + 1 < 0)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = startIndex; i >= startIndex - count + 1; i--)
        {
            if (Compare(value, list[i]))
            {
                return i;
            }
        }

        return -1;
    }

    //●	Foreach
    public static void ForEach<T>(List<T> list, Action<T> action)
    {
        foreach (var item in list)
        {
            action.Invoke(item);
        }
    }


    //●	TrueForAll
    public static bool TrueForAll<T>(List<T> list, Predicate<T> condition)
    {
        foreach (var item in list)
        {
            if (!condition.Invoke(item))
            {
                return false;
            }
        }

        return true;
    }

    private static bool Compare<T>(T value, T? item) =>
        value is not null && item is not null && item.Equals(value);
}