using System;
using System.Collections.Generic;

namespace Parking.ValueObject
{
    public class Car : IValueObject, IEquatable<Car>
    {
        public string Id { get; }

        public Car(string id)
        {
            Id = id;
        }


        public override string ToString()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Car);
        }

        public bool Equals(Car other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(Car left, Car right)
        {
            return EqualityComparer<Car>.Default.Equals(left, right);
        }

        public static bool operator !=(Car left, Car right)
        {
            return !(left == right);
        }
    }
}