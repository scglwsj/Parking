using System;
using System.Collections.Generic;

namespace Parking.ValueObject
{
    public class BoyId : IValueObject, IEquatable<BoyId>
    {
        public BoyId()
        {
            Id = Guid.NewGuid().ToString();
        }

        public BoyId(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as BoyId);
        }

        public bool Equals(BoyId other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return Id;
        }

        public static bool operator ==(BoyId left, BoyId right)
        {
            return EqualityComparer<BoyId>.Default.Equals(left, right);
        }

        public static bool operator !=(BoyId left, BoyId right)
        {
            return !(left == right);
        }
    }
}