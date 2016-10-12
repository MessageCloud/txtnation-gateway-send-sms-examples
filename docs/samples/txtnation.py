import urllib.parse
import urllib.request

url = 'http://client.txtnation.com/gateway.php'
values = {
	"reply"		: "1",
	"id"		: "1234",
	"number"	: "07123456789",
	"network"	: "network",
	"message"	: "My test message",
	"cc"		: "Test Company",
	"currency"	: "CUR",
	"value"		: "12.3",
	"ekey"		: "key",
	"title"		: "from title"
}
data = urllib.parse.urlencode(values).encode("utf-8")
req = urllib.request.Request(url, data)
response = urllib.request.urlopen(req)
the_page = response.read()



