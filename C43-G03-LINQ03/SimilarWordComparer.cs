using System.Diagnostics.CodeAnalysis;

namespace C43_G03_LINQ03
{
    public class SimilarWordComparer : IEqualityComparer<SimilarWordComparer>
    {
        public bool Equals(SimilarWordComparer? x, SimilarWordComparer? y)
        {
            return x == y;
        }

        public int GetHashCode([DisallowNull] SimilarWordComparer obj)
        {
            return obj.GetHashCode();
        }
    }
}
