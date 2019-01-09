using Echenim.Nine.Util.UniqueReferenceGenerator.Contracts;
using Echenim.Nine.Util.UniqueReferenceGenerator.Data;

namespace Echenim.Nine.Util.UniqueReferenceGenerator.Processs
{
    public class ReferenceGenerator
    {
        private readonly IGenerators _generators;

        public ReferenceGenerator()
        {
            _generators = new Generators();
        }

        public string GenerateId(string userreferencenumber)
        {
            return _generators.TrackingNumber(userreferencenumber);
        }

        public string GenerateId()
        {
            return _generators.TrackingNumber();
        }

        public string NGeneratedId(int lenght)
        {
            return _generators.NLenghtTrackingNumber(lenght);
        }



    }
}
