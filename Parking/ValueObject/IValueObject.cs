namespace Parking.ValueObject
{
    public interface IValueObject
    {
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}
