using System.IO;
using System.Net;

namespace Echenim.Nine.Util.Messaging
{
    public class sms
    {
        public string SendSms(string toMobile,string from, string messageBody,string apiKey,string apiSecret)
        {
            var message = $"https://rest.nexmo.com/sms/json?api_key={apiKey}&api_secret={apiSecret}&to={toMobile}&from=NEXMO&text={messageBody}";
            var result = string.Empty;
            var webrequest = (HttpWebRequest)WebRequest.Create(message);
            webrequest.Method = "POST";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            var requestStream = webrequest.GetRequestStream();
            //requestStream.Write(bytes, 0, bytes.Length);

            var getresponse = webrequest.GetResponse();
            var stream = getresponse.GetResponseStream();
            if (stream != null)
            {
                var streamreader = new StreamReader(stream);

                result = streamreader.ReadToEnd();
                stream.Dispose();
                streamreader.Dispose();

            }

            return result;
        }


    }
}
