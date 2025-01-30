using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_ADV01
{
    public class Range<T> where T : IComparable<T>
    {
        private T _min;
        private T _max;

        public Range(T min, T max)
        {
            _min = min;
            _max = max;
        }

        public bool IsInRange(T value)
        {
            return
                (value.CompareTo(_min) is 0 or 1) &&
                (value.CompareTo(_max) is 0 or -1);
        }

        public T Length()
        {
            return (dynamic)_max - _min;
        }
    }
}

/*
2. create a generic Range<T> class that represents a range of values from a
minimum value to a maximum value. The range should support basic
operations such as checking if a value is within the range and
determining the length of the range.

Requirements:

1. Create a generic class named Range<T> where T represents the type of values.

2. Implement a constructor that takes the minimum and maximum values to define the range.

3. Implement a method IsInRange(T value) that returns true if the given value is within the range,
otherwise false.

4. Implement a method Length() that returns the length of the range
(the difference between the maximum and minimum values).

5. Note: You can assume that the type T used in the Range<T> class implements the
IComparable<T> interface to allow for comparisons.
*/