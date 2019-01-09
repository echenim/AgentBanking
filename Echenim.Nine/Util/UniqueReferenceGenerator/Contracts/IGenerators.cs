namespace Echenim.Nine.Util.UniqueReferenceGenerator.Contracts
{
    interface IGenerators
    {
        string TrackingNumber();
        string TrackingNumber(string userreferencednumber);

        string NLenghtTrackingNumber(int lenght);

    }
}
