require 'net/http'
require 'uri'

def send_sms(reply, id, number, network, message, cc, currency, value, ekay, title)
	requested_url = 'http://client.txtnation.com/gateway.php?' + "reply=" + reply + "&id=" + id + "&number=" + number + "&network=" + network + "&message=" + URI.escape(message) + "&cc=" + cc + "&currency=" + currency + "&value=" + value + "&ekey=" + ekey + "&title=" + title
	url = URI.parse(requested_url)
	full_path = (url.query.blank?) ? url.path : "#{url.path}?#{url.query}"
	the_request = Net::HTTP::Get.new(full_path)
	the_response = Net::HTTP.start(url.host, url.port) { |http|
		http.request(the_request)
	}
	raise "Response was not 200, response was #{the_response.code}" if the_response.code != "200"
	return the_response.bodyend
resp = send_sms("1", "1234", "07123456789", "network", "My test message", "Test Company", "CUR", "12.3", "key", "from title")

puts(resp)
