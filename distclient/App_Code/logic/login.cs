using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class login
{
	public Boolean authenticate(String usr, String pass)
	{
        user u = new user();
        encryption crypt = new encryption();
        connection conn = new connection();

        u.overallID = "logIn";
        u.email = usr;
        u.password = pass;
        u.isAdmin = false;

        String jsonstring = JsonConvert.SerializeObject(u);
    

        String output = crypt.EncryptDecrypt(jsonstring);

        String reply = conn.connect(output);

        String value = reply.Substring(0, 1);

        HttpContext.Current.Session["userID"] = reply.Substring(1);

        if (value.Equals("0"))
        {
            return true;
        }
        else if (value.Equals("3"))
        {
            return false; // "Your password does not match";
        }
        else if (value.Equals("2"))
        {
            return false; // "The user you have logged in as, is marked as inactive";
        }
        else if (value.Equals("1"))
        {
            return false; // "The email doesn't exist";
        }
        else
        {
            return false; // "An error has occured";
        }
   
	}
}