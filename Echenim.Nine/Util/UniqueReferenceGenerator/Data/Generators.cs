using System;
using System.Security.Cryptography;
using Echenim.Nine.Util.UniqueReferenceGenerator.Contracts;

namespace Echenim.Nine.Util.UniqueReferenceGenerator.Data
{
    internal class Generators:IGenerators
    {
       /// <summary>
       /// generate unique id by combining user reference with the current time stamp
       /// </summary>
       /// <param name="userreferencednumber">user reference number</param>
       /// <returns>unique rference id</returns>
        public string TrackingNumber(string userreferencednumber) => userreferencednumber == null
            ? $"{DateTime.Now:HH}{DateTime.Now:mm}{DateTime.Now:ss}{DateTime.Now.Millisecond}"
            : userreferencednumber + $"{DateTime.Now:HH}{DateTime.Now:mm}{DateTime.Now:ss}{DateTime.Now.Millisecond}";

        public string NLenghtTrackingNumber(int lenght)
        {
            var bytes = new byte[lenght];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return $"{BitConverter.ToInt64(bytes, 0)}";
        }

        public string TrackingNumber()
            => $"{DateTime.Now:HH}{DateTime.Now:mm}{DateTime.Now:ss}{DateTime.Now.Millisecond}";






    }
}
