using System;

namespace Echenim.Nine.Misc.Functionals.ErrorsAndFailures
{
    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage) 
            where T : class => maybe.HasNoValue ? Result.Fail<T>(errorMessage) : Result.Ok(maybe.Value);

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsFailure)
                return result;

            action();

            return Result.Ok();
        }

        public static Result OnSuccess(this Result result, Func<Result> func) => result.IsFailure ? result : func();

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result OnBoth(this Result result, Action<Result> action)
        {
            action(result);

            return result;
        }

        public static T OnBoth<T>(this Result result, Func<Result, T> func) => func(result);
    }
}
