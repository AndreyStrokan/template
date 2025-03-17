using System;

public interface IReactiveProperty<T>
{
    event Action PropertyChanged;

    T Value { get; set; }
}