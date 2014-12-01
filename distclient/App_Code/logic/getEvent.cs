using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for getEvent
/// </summary>
public class getEvent
{
	public String getEvents()
    {
        customevents e = new customevents();
        encryption crypt = new encryption();
        connection conn = new connection();

        e.overallID = "getEventInfo";
        e.CalenderID = "1";

        String jsonstring = JsonConvert.SerializeObject(e);

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        return reply;
    }

    public ESObject0 getCBSEvents()
    {
        getEvent ge = new getEvent();
        encryptUserID eui = new encryptUserID();
        String user = System.Web.HttpContext.Current.Session["username"].ToString();
        String encrypted = eui.encryptuser(System.Web.HttpContext.Current.Session["username"].ToString());
        string json = new WebClient().DownloadString("http://calendar.cbs.dk/events.php/"+ user + "/" + encrypted + ".json");
        ESObject0 obj = JsonConvert.DeserializeObject<ESObject0>(json);
        return obj;
    }
}