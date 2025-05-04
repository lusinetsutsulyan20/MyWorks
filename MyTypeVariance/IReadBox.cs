namespace IReadBoxNamespace
{
    public interface IReadBox<out T>
    {
        T this [int index] {get;}
    }
}