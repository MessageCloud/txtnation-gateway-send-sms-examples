import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.URL;
import java.net.URLConnection;
import java.net.URLEncoder;

// Simple send SMS programm
public class SendSMS {
    public static String sendSMS(String reply, String id, String number, String network, String message, String cc, String currency, String value, String ekey, String title) {
        String url;
        StringBuilder inBuffer = new StringBuilder();
        try {
            url = "http://client.txtnation.com/gateway.php?" + "reply=" + reply + "&id=" + id + "&number=" + number + "&network=" + network + "&message=" + URLEncoder.encode(message, "UTF-8") + "&cc=" + cc + "&currency=" + currency + "&value=" + value + "&ekey=" + ekey + "&title=" + title;
        } catch (UnsupportedEncodingException e) {
            return null;
        }
        try {
            URL tmUrl = new URL(url);
            URLConnection tmConnection = tmUrl.openConnection();
            tmConnection.setDoInput(true);
            BufferedReader in = new BufferedReader(new InputStreamReader(tmConnection.getInputStream()));
            String inputLine;
            while ((inputLine = in.readLine()) != null)
                inBuffer.append(inputLine);
            in.close();
        } catch (IOException e) {
            return null;
        }
        return inBuffer.toString();
    }
    public static void main(String[] args) {
        // Example of use
        String response = sendSMS("1", "1234", "07123456789", "network", "My test message", "Test Company", "CUR", "12.3", "key", "from title");
        System.out.println(response);
    }
}
