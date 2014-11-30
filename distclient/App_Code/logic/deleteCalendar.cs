using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for deleteCalendar
/// </summary>
public class deleteCalendar
{
    public String dc()
    {
        calendar e = new calendar();
        encryption crypt = new encryption();
        connection conn = new connection();

        e.overallID = "deleteCalender";
        e.calenderName = "My Calendar";
        e.userName = "anha13ao";


        String jsonstring = JsonConvert.SerializeObject(e);

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        return reply;
    }
}