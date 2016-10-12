<?php

// Simple SMS send function
function sendSMS($reply, $id, $number, $network, $message, $cc, $currency, $value, $ekay, $title) {
    $URL = 'http://client.txtnation.com/gateway.php?';
    $URL .= http_build_query([
    	'reply'		=> $reply,
    	'id'		=> $id,
    	'number'	=> $number,
    	'network'	=> $network,
    	'message'	=> urlencode($message),
    	'cc'		=> $cc,
    	'currency'	=> $currency,
    	'value'		=> $value,
    	'ekey'		=> $ekay,
    	'title'		=> $title
    ]);
    $fp = fopen($URL, 'r');
    return fread($fp, 1024);
}
// Example of use
$response = sendSMS("1", "1234", "07123456789", "network", "My test message", "Test Company", "CUR", "12.3", "key", "from title");
echo $response;
