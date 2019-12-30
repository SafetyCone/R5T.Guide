using System;


namespace R5T.Guide
{
    /// <summary>
    /// Allow wrapping a Guid with a specific type.
    /// This is helpful in creating strongly-typed Guid for Guidly-typed data. Examples: FileGuid for uniquely identifying a file.
    /// Value is mutable.
    /// </summary>
    public class MutableTypedGuid : IEquatable<MutableTypedGuid>, IComparable<MutableTypedGuid>
    {
        #region Static

        /// <summary>
        /// Centralizes the methodology for getting a new Guid value.
        /// </summary>
        public static Guid GetNewGuid()
        {
            var guid = Guid.NewGuid();
            return guid;
        }

        #endregion


        public Guid Value { get; set; }


        public MutableTypedGuid()
        {
        }

        public MutableTypedGuid(Guid value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var objAsTypedGuid = obj as MutableTypedGuid;

            var isEqual = this.Equals_Internal(objAsTypedGuid);
            return isEqual;
        }

        protected virtual bool Equals_Internal(MutableTypedGuid other)
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
            var representation = this.Value.ToString();
            return representation;
        }

        public bool Equals(MutableTypedGuid other)
        {
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Internal(other);
            return isEqual;
        }

        public int CompareTo(MutableTypedGuid other)
        {
            var output = this.Value.CompareTo(other.Value);
            return output;
        }
    }
}
