<%@ language="JScript" %>
<%
    reply   = "1";
    id      = "1234";
    number  = "07123456789";
    network = "network";
    message = "My test message";
    cc      = "Test Company";
    currency= "CUR";
    value   = "12.3";
    ekey    = "key";
    title   = "from title";
    url = "http://client.txtnation.com/gateway.php?" + "reply=" + reply + "&id=" + id + "&number=" + number +  "&network=" + network + "&message=" + message + "&cc=" + cc + "&currency=" + currency + "&value=" + value + "&ekey=" + ekey + "&title=" + title;
    var objSrvHTTP;
    objSrvHTTP = Server.CreateObject("Msxml2.ServerXMLHTTP");
    objSrvHTTP.open(url, false);
    objSrvHTTP.send();
    Response.ContentType = "text/xml";
    xmlResp = objSrvHTTP.responseXML.xml;
    Response.Write(xmlResp);
%>
