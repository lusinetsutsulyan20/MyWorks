using System;
using System.Collections;
namespace MyArray{

public class MyArrayList : ICloneable, IEnumerable
{
    public int Count {get;set;}
    private int _capacity = 2;

    private object[] _array = new object[2];

    public object this [int index]
    {
        get
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));   
            }
            return _array[index];
        }
        set
        {
            Insert(index, value);
        }
    }

    public MyArrayList ()
    {
        if (_array == null)
        {
            _array = new object[_capacity];
        }
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return _array[i];
        }
    }

    public object Clone()
    {
        return (MyArrayList)MemberwiseClone();
    }


    public void Add(object item)
    {
        if (Count == _capacity)
        {
            Resize();
        }
         _array[Count] = item;
        ++Count;
    }
    private void Resize()
    {
        _capacity *= 2;
        object[] tmp = new object[_capacity];
        for (int i = 0; i < Count; i++)
        {
            tmp[i] = _array[i];
        }
        _array = tmp;
    }


    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        for (int i = index; i < Count - 1; i++)
        {
            _array[i] = _array[i + 1];
        }
        --Count;
        _array[Count] = default;
    }


    public void Remove(object item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (object.Equals(_array[i], item))
            {
                RemoveAt(i);
                --i;
            }
        } 
    }


    public bool Contains(object item)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (object.Equals(_array[i], item))
            {
                return true;
            }
        }
        return false;
    }

    public void Insert(int index, object item)
    {
        if ((_array == null) || (index >= Count))
        {
            Add(item);
            return;
        }
        
        if (Count == _capacity || index > Count)
        {
            Resize();
        }

        for (int i = Count; i > index; i--)
        {
            _array[i] = _array[i - 1];
        }
        _array[index] = item;
        ++Count;
    }
    public int BinarySearch(Object obj, IComparer cmp)
    {
        int left = 0;
        int right = Count - 1;

        while (left <= right)
        {
            // int mid = (right + left) / 2;
            int mid = left + (right - left) / 2;

            int comparison = cmp.Compare(_array[mid], obj);

            if (comparison == 0)
            {
                return mid;
            } 
            else if (comparison < 0) // 1 < 2
            {
                left = mid + 1;
            } 
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    public void Print()
    {
        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine (_array[i].ToString());
        }
    }
}
}
