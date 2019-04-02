namespace Parking.ValueObject
{
    public class Car
    {
        public string Id { get; }

        public Car( string id)
        {
            Id = id;
        }
    }
}