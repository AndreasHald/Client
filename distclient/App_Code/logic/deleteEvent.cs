using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// VIRKER IKKE ENDNU SOCKET WRITE EXCEPTION
/// </summary>
public class deleteEvent
{
	public String dE()
	{
        customevents e = new customevents();
        encryption crypt = new encryption();
        connection conn = new connection();

        e.overallID = "deleteEvent";
        e.eventid = "1";


        String jsonstring = JsonConvert.SerializeObject(e);

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        return reply;
	}
}