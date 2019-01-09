using System;
using Echenim.Nine.Util.UniqueReferenceGenerator.Contracts;

namespace Echenim.Nine.Util.UniqueReferenceGenerator.Data
{
   internal class RandomIdentifier:IGenerators
    {
        /// <summary>
        /// generate unique id by combining user reference with the current time stamp
        /// </summary>
        /// <param name="userreferencednumber">user reference number</param>
        /// <returns>unique rference id</returns>
        public string TrackingNumber(string userreferencednumber) => $"{Guid.NewGuid()}-{userreferencednumber}-{DateTime.Now:HH}{DateTime.Now:mm}{DateTime.Now:ss}{DateTime.Now.Millisecond}";

       public string NLenghtTrackingNumber(int lenght)
       {
           throw new NotImplementedException();
       }

       public string TrackingNumber()
            => $"{Guid.NewGuid()}-{DateTime.Now:HH}{DateTime.Now:mm}{DateTime.Now:ss}{DateTime.Now.Millisecond}";


    }
}
