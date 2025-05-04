namespace IWriteBoxNamespace
{
    public interface IWriteBox<in T>
    {
        void Add(T item);
    }
}