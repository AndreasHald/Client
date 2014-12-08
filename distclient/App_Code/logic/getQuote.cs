using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for getQuote
/// </summary>
public class getQuote
{
	public String gQ(quot e)
	{
		encryption crypt = new encryption();
        connection conn = new connection();

        String jsonstring = JsonConvert.SerializeObject(e);

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        return reply;
	}
}