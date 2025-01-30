using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_ADV01
{
    public class FixedSizeList<T>
    {
        private T[] array;

        private int cursor;

        public FixedSizeList(int capacity)
        {
            array = new T[capacity];
            cursor = 0;
        }

        public int Add(T item)
        {
            if (cursor < array.Length)
            {
                array[cursor] = item;
                return cursor++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public T Get(int index)
        {
            if (index > -1 && index < array.Length)
            {
                return array[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}

/*
5. implement a custom list called FixedSizeList<T> with a predetermined
capacity. This list should not allow more elements than its capacity and
should provide clear messages if one tries to exceed it or access invalid
indices.
Requirements:
1. Create a generic class named FixedSizeList<T>.
2. Implement a constructor that takes the fixed capacity of the list as a
parameter.
3. Implement an Add method that adds an element to the list, but
throws an exception if the list is already full.
4. Implement a Get method that retrieves an element at a specific index
in the list but throws an exception for invalid indices.
*/