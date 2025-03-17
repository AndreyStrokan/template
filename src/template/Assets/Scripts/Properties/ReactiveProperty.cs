using System;

public class ReactiveProperty<T> : IReactiveProperty<T>
{
    public event Action PropertyChanged;

    private T value;
    public T Value
    {
        get => value;
        set
        {
            this.value = value;
            PropertyChanged?.Invoke();
        }
    }
}