namespace C43_G03_LINQ01;

public class CaseInsensitiveComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x is null)
            return 1;

        if (y is null)
            return -1;

        string xUpper = x.ToUpper();
        string yUpper = y.ToUpper();
        
        int shortest =
            xUpper.Length > yUpper.Length ? yUpper.Length : xUpper.Length;

        for (int i = 0; i < shortest; i++)
        {
            if (xUpper[i] < yUpper[i])
            {
                return -1;
            }
            else if (xUpper[i] > yUpper[i])
            {
                return 1;
            }
        }

        return 0;
    }
}
