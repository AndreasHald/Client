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
	public String cc(calendar e)
	{

        encryption crypt = new encryption();
        connection conn = new connection();

        String jsonstring = JsonConvert.SerializeObject(e);

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        return reply;
	}
}