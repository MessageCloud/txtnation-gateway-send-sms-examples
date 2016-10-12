var http = require('http');

function getTestPersonaLoginCredentials(callback) {

	return http.get({
		host: 'http://client.txtnation.com',
		path: '/gateway.php',
		qs:{
			reply		: "1",
			id			: "1234",
			number		: "07123456789",
			network		: "network",
			message		: "My test message",
			cc			: "Test Company",
			currency	: "CUR",
			value		: "12.3",
			ekey		: "key",
			title		: "from title"
		}
	}, function(response) {
		// Continuously update stream with data
		var body = '';
		response.on('data', function(d) {
			body += d;
		});
		response.on('end', function() {
			callback(body);
		});
	});

}
