﻿using System.Collections.Generic;

namespace TpsParser.Tps.Type
{
    /// <summary>
    /// Represents a typed object within the TopSpeed file.
    /// </summary>
    public abstract class TpsObject
    {
        /// <summary>
        /// Gets the .NET equivalent value of the TopSpeed object.
        /// </summary>
        public object Value { get; protected set; }

        /// <summary>
        /// Gets the type code of the object.
        /// </summary>
        public abstract TpsTypeCode TypeCode { get; }

        /// <summary>
        /// Gets the string representation of the value that this object encapsulates.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Value?.ToString();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override bool Equals(object obj)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            if (obj is TpsObject o)
            {
                return Value?.Equals(o.Value) ?? false;
            }
            else
            {
                return false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override int GetHashCode()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            var hashCode = -1431579180;
            hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + TypeCode.GetHashCode();
            return hashCode;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator ==(TpsObject left, TpsObject right)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return EqualityComparer<TpsObject>.Default.Equals(left, right);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator !=(TpsObject left, TpsObject right)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return !(left == right);
        }
    }

    /// <summary>
    /// Represents a typed object within the TopSpeed file.
    /// </summary>
    /// <typeparam name="T">The .NET equivalent type of the value this object encapsulates.</typeparam>
    public abstract class TpsObject<T> : TpsObject
    {
        /// <inheritdoc/>
        public new T Value
        {
            get => _typedValue;
            protected set
            {
                _typedValue = value;
                base.Value = value;
            }
        }
        private T _typedValue;
    }
}
