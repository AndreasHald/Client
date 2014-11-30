using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for createCalendar
/// </summary>
public class createCalendar
{
	public String cc()
	{
        calendar e = new calendar();
        encryption crypt = new encryption();
        connection conn = new connection();

        e.overallID = "createCalender";
        e.calenderName = "My Calendar";
        e.userName = "anha13ao";
        e.publicOrPrivate = 1;
 

        String jsonstring = JsonConvert.SerializeObject(e);

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        return reply;
	}
}