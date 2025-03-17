public class Config<T>
{
  public T Value { get; private set; }
  public Config(T value) => Value = value;
  public void SetValue(T newValue) => Value = newValue;
}