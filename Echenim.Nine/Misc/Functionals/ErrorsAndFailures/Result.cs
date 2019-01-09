using System;
using System.Linq;

namespace Echenim.Nine.Misc.Functionals.ErrorsAndFailures
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string error)
        {
            if (isSuccess && error != string.Empty)
                throw new InvalidOperationException();
            if (!isSuccess && error == string.Empty)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Fail(string message) => new Result(false, message);

        public static Result<T> Fail<T>(string message) => new Result<T>(default(T), false, message);

        public static Result Ok() => new Result(true, string.Empty);

        public static Result<T> Ok<T>(T value) => new Result<T>(value, true, string.Empty);

        public static Result Combine(params Result[] results)
        {
            foreach (var result in results.Where(result => result.IsFailure))
            {
                return result;
            }

            return Ok();
        }
    }


    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();

                return _value;
            }
        }

        protected internal Result(T value, bool isSuccess, string error)
            : base(isSuccess, error)
        {
            _value = value;
        }
    }
}
