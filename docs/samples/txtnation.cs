using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace SendSMS {
    class Program {
        public static string SendSMS(string reply, string id, string number, string network, string message, string cc, string currency, string value, string ekey, string title) {
            StringBuilder sb  = new StringBuilder();
            byte[]        buf = new byte[1024];
            string url = "http://client.txtnation.com/gateway.php?" + "reply=" + reply + "&id=" + id + "&number=" + number + "&network=" + network + "&message=" + HttpUtility.UrlEncode(message) + "&cc=" + cc + "&currency=" + currency + "&value=" + value + "&ekey=" + ekey + "&title=" + title;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            do {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0) {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);
                    sb.Append(tempString);
                }
            }
            while (count > 0);
            return sb.ToString();
        }
        static void Main(string[] args) {
            string respXML = SendSMS("1", "1234", "07123456789", "network", "My test message", "Test Company", "CUR", "12.3", "key", "from title");
            Console.WriteLine(respXML);
       }
    }
}
