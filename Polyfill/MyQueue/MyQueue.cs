using System;
using System.Collections;
namespace MyQueue{

public class MyQueue <T> : IEnumerable<T>
{
    T[] _array;
    public int Count {get; private set;}
    private int _capacity = 2;

    public MyQueue ()
    {
        _array = new T[_capacity];
    }

    public void Enqueue (T item)
    {
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
    public void Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        
        for (int i = 1; i < Count; i++)
        {
            _array[i - 1] = _array[i];
        }
        _array[--Count] = default;
    }
    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        return _array[0];
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
}
