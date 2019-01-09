using Echenim.Nine.Util.UniqueReferenceGenerator.Contracts;
using Echenim.Nine.Util.UniqueReferenceGenerator.Data;

namespace Echenim.Nine.Util.UniqueReferenceGenerator.Processs
{
    public class RandomReferenceIdentifier
    {
        private readonly IGenerators _generators;
        public RandomReferenceIdentifier()
        {
            _generators = new RandomIdentifier();
        }

        public string RandomIdentifier(string userreferencenumber)
        {
            return _generators.TrackingNumber(userreferencenumber);
        }

        public string RandomIdentifier()
        {
            return _generators.TrackingNumber();
        }



    }
}