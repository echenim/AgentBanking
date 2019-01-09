using System;

namespace Echenim.Nine.Misc.Functionals.ErrorsAndFailures
{
    public struct Maybe<T> : IEquatable<Maybe<T>>
        where T : class
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (!HasNoValue) return _value;
                throw new InvalidOperationException();
            }
        }

        public bool HasValue => _value != null;
        public bool HasNoValue => !HasValue;

        private Maybe([AllowNull] T value)
        {
            _value = value;
        }

        public static implicit operator Maybe<T>([AllowNull] T value)
        {
            return new Maybe<T>(value);
        }

        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (maybe.HasNoValue)
                return false;

            return maybe.Value.Equals(value);
        }

        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return !(maybe == value);
        }

        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Maybe<T>)) return false;
            var other = (Maybe<T>) obj;
            return Equals(other);
        }

        public bool Equals(Maybe<T> other) => HasNoValue && other.HasNoValue || !HasNoValue && !other.HasNoValue && _value.Equals(other._value);

        public override int GetHashCode() => _value.GetHashCode();

        public override string ToString() => HasNoValue ? "No value" : Value.ToString();

        [return: AllowNull]
        public T Unwrap([AllowNull] T defaultValue = default(T)) => HasValue ? Value : defaultValue;
    }
}