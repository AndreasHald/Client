using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for configuration
/// </summary>
public class configuration
{
    private static String host = "10.0.0.60";
    private static int port = 8888;
    private static int encryptionkey = 17;
	
    public String getHost()
    {
        return host;
    }
    public int getPort()
    {
        return port;
    }
    public int getEncryptionkey()
    {
        return encryptionkey;
    }
}