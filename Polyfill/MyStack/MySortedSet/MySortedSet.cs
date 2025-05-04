using System;
using System.Collections;
using System.Runtime.CompilerServices;
namespace MySortedSetImp;

public class MySortedSet<T> : IEnumerable<T>
{
    public T[] _array;
    private int _capacity = 2;
    public int Count {get; private set;}

    public MySortedSet()
    {
        _array = new T[_capacity];
    }
    public void Add(T item)
    {
        if (_array == null)
        {
            _array = new T[_capacity];
        }
        if (BinarySearch(item) == false)
        {
            throw new InvalidOperationException($"The item '{item}' already exists in the set.");
        }
        if (Count == _capacity)
        {
            Resize();
        }
        _array[Count] = item;
        ++Count;
    }

    public void Resize()
    {
        _capacity *= 2;
        T[] tmp = new T[_capacity];

        for (int i = 0; i < Count; i++)
        {
            tmp[i] = _array[i];
        }
        _array = tmp;
    }
    
    public void Remove(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            bool isContain = false;
            if (isContain)
            {
                _array[i - 1] = _array[i];
            }
            if (object.Equals(_array[i], item) && (item != null))
            {
                isContain = true;
            }
        }
        _array[--Count] = default;
    }

    public bool Contain (T item)
    {
        return BinarySearch(item);
    }

    public void Clear()
    {
        _array = null;
        Count = 0;
        _capacity = 2;
    }

    private bool BinarySearch(T item)
    {
        T[] copy = MyClone();
        Array.Sort(copy);

        int left = 0;
        int right = copy.Length - 1;

        while (left < right)
        {
            int mid = (right - left) / 2;
            int comparison = Comparer<T>.Default.Compare(item, copy[mid]);

            if (comparison == 0)
            {
                return true;
            } 
            else if (comparison < 0)   
            {
                left = mid;
            } 
            else
            {
                right = mid;
            }
        }
        return false;
    }

    private T[] MyClone()
    {
        T[] fake = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            fake[i] = _array[i];
        }
        return fake;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return _array[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) GetEnumerator();
    }
}
