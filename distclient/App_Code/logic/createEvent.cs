using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for createEvent
/// </summary>
public class createEvent
{
	public String ce()
	{
        customevents e = new customevents();
        encryption crypt = new encryption();
        connection conn = new connection();

        e.overallID = "createEvent";
        e.type = "1";
        e.location = "Sp212";
        e.createdby = "1";
        e.startTime = "2014-11-27 12:00.00";
        e.endTime = "2014-11-28 12:00.00";
        e.name = "mit test event";
        e.text = "teksten til mit test event";
        e.customevent = "0";
        e.CalendarID = "1";

        String jsonstring = JsonConvert.SerializeObject(e);

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        return reply;
	}
}