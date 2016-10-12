#include <iostream>
#include <string>
#using <System.Dll>
#using <System.Web.Dll>

using namespace std;
using namespace System;
using namespace System::Web;
using namespace System::Net;
using namespace System::IO;
using namespace System::Runtime::InteropServices;

ref class SMSSender
{

public:
        SMSSender()
        {}
        String^ SendSMS(String^ reply, String^ id, String^ number, String^ network, String^ message, String^ cc, String^ currency, String^ value, String^ ekey, String^ title)
        {
                message = HttpUtility::UrlEncode(message);
                String^ URL = "http://client.txtnation.com/gateway.php?" + "reply=" + reply + "&id=" + id + "&number=" + number + "&network=" + network + "&message=" + message + "&cc=" + cc + "&currency=" + currency + "&value=" + value + "&ekey=" + ekey + "&title=" + title;
                WebRequest^ Handle = WebRequest::Create(URL);
                WebResponse^ HTTPResponse = Handle->GetResponse();
                StreamReader^ Stream = gcnew StreamReader(HTTPResponse->GetResponseStream());
                String^ Response = Stream->ReadToEnd()->Trim();
                HTTPResponse->Close();
                return Response;
        }
};

int main() {
        SMSSender^ test = gcnew SMSSender();
        String^ resp = test->SendSMS("1", "1234", "07123456789", "network", "My test message", "Test Company", "CUR", "12.3", "key", "from title");
        Console::WriteLine(resp);
        return 0;
}
