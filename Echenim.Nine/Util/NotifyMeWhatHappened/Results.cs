//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Echenim.Nine.Util.NotifyMeWhatHappened
//{
//   public class Result
//   {
//        public bool Success { get; private set; }

//        public string Error { get; private set; }

//        public bool Failure;
//        protected Result(bool success, string error) { /* … */ }
//        public static Result Fail(string message) { /* … */ }
//        public static Result<T> Ok<T>(T value) {  /* … */ }

//    }


//    public class Result<T> : Result
//    {
//        public T Value { get; set; }
//        protected internal Result(T value, bool success, string error): base(success, error){/* … */}

//    }


//}
