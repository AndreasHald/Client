using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for getCalendar
/// </summary>
public class getCalendar
{
    public String dc(String userID)
    {
        calendar e = new calendar();
        encryption crypt = new encryption();
        connection conn = new connection();

        e.overallID = "getCalender";
        e.userName = userID;


        String jsonstring = JsonConvert.SerializeObject(e);

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        return reply;
    }
}