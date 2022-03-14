using Assignment2022_NCC.Api.Types;

public interface IBasicCache<T>
{
    void Update(T response);
    bool HasValue();
    T? Read();
}

public class BasicCache<T> : IBasicCache<T> where T : class
{
    private T? _value;

    public bool HasValue()
    {
        return _value != null;
    }

    public void Update(T response)
    {
        _value = response;
    }

    public T Read()
    {
        return _value;
    }
}
