using System;


namespace R5T.Guide
{
    /// <summary>
    /// Allow wrapping a Guid with a specific type.
    /// This is helpful in creating strongly-typed Guid for Guidly-typed data. Examples: FileGuid for uniquely identifying a file.
    /// Value is read-only.
    /// </summary>
    public class TypedGuid : IEquatable<TypedGuid>, IComparable<TypedGuid>
    {
        public string Value { get; }


        public TypedGuid(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var objAsTypedGuid = obj as TypedGuid;

            var isEqual = this.Equals_Internal(objAsTypedGuid);
            return isEqual;
        }

        protected virtual bool Equals_Internal(TypedGuid other)
        {
            var isEqual = this.Value.Equals(other.Value);
            return isEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return this.Value;
        }

        public bool Equals(TypedGuid other)
        {
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Internal(other);
            return isEqual;
        }

        public int CompareTo(TypedGuid other)
        {
            var output = this.Value.CompareTo(other.Value);
            return output;
        }
    }
}
