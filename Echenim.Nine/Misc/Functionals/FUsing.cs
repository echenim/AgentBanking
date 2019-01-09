using System;


namespace Echenim.Nine.Misc.Functionals
{
   

    /// <summary>
    /// This class attempt to implement Using method in functional style
    /// WHY: in order to avoid mutability that is a plague of object oriented style
    /// </summary>
    public static class FUsing
    {

        /// <summary> 
        ///  using method that accept the instance of the type, that implement IDisposable also return a type result of a 
        /// using block
        /// </summary>
        /// <typeparam name="TDisposable"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="disposable"></param>
        /// <returns></returns>
        public static TResult Using<TDisposable, TResult>(TDisposable disposable)
              where TDisposable : IDisposable
        {
            using (disposable)
            {
                return default(TResult);
            }

        }

        /// <summary>
        /// /// Refactory II
        ///  we need a way to generically operate on this method, we turn the using method into a higher 
        /// order function by accepting a delegate as a parameter, the parameter is mapping the
        /// TDisposable to TResult.
        /// </summary>
        /// <typeparam name="TDisposable"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="disposable"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static TResult Using<TDisposable, TResult>(TDisposable disposable, Func<TDisposable, TResult> map)
              where TDisposable : IDisposable
        {
            using (disposable)
            {
                return map(disposable);
            }

        }


        /// <summary>
        /// Refactory III
        /// problem with refactory II, is that we are accepting a preconstructed IDisposabel
        /// instance, this mean the using method is not fully controlling the instances life cycle
        /// by accepting the existing instance, we  rub the chance of some side effect, modifing the instance
        /// WHY: the goal is to fully control the instance life cycle by converting the first parameter to another Func<>
        /// that define how to create the disposable
        /// </summary>
        /// <typeparam name="TDisposable"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="factory"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static TResult Using<TDisposable, TResult>(Func<TDisposable> factory, Func<TDisposable, TResult> map)
              where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return map(disposable);
            }

        }
    }
}
