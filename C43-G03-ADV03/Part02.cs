namespace C43_G03_ADV03;

//1.	Considering the Code Below, Write Down the Body of all Listed Methods and Properties and Constructor:
public class Book
{
    public string ISBN { get; set; }

    public string Title { get; set; }

    public string[] Authors { get; set; }

    public DateTime PublicationDate { get; set; }

    public decimal Price { get; set; }

    public Book(string _ISBN, string _Title, string _Author, DateTime _PublicationDate, decimal _Price)
    {
        ISBN = _ISBN;
        Title = _Title;
        Authors = _Author.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        PublicationDate = _PublicationDate;
        Price = _Price;
    }

    public override string ToString()
    {
        return $"{Title} by {string.Join(",", Authors)} [{PublicationDate:yyyy/MM/dd}]";
    }
}

public class BookFunctions
{
    public static string GetTitle(Book B)
    {
        return B.Title;
    }

    public static string GetAuthor(Book B)
    {
        return string.Join(", ", B.Authors);
    }

    public static string GetPrice(Book B)
    {
        return $"{B.Price:C}";
    }
}

//2.	You need to parameterize ProcessBooks function to accept BookFunctions Methods using following cases: 

//a) Create User Defined Delegate with the same signature of methods existed in Bookfunctions class.
public delegate string BookFunctionsDelegate(Book B);


public class LibraryEngine
{
    public static void ProcessBooks(List<Book> bList, BookFunctionsDelegate fPtr)
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }

    //b) Use the Proper build in delegate.
    public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }

    //c) Anonymous Method (GetISBN).
    public static void GetISBN(List<Book> bList)
    {
        string r;
        foreach (Book B in bList)
        {
            Console.WriteLine(delegate ()
            {
                return B.ISBN + "\n";
            });
        }
    }

    //d) Lambda Expression (GetPublicationDate).
    public static void GetPublicationDate(List<Book> bList)
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(() => B.PublicationDate + "\n");
        }
    }
}