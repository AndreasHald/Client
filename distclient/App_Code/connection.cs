using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using System.IO; 


public class connection
{
	public String connect(String jsonstring)
	{
        configuration cf = new configuration();
        String server = cf.getHost(); // Server name or IP address
        int port = cf.getPort();


        // Convert input String to bytes
        byte[] byteBuffer = Encoding.ASCII.GetBytes(jsonstring);

        TcpClient client = null;
        NetworkStream ns = null;

        try
        {
            // Create socket that is connected to server on specified port
            client = new TcpClient(server, port);
            //client.SendTimeout = 1000000000;
            //Response.Write("Connected to server... sending echo string");

            ns = client.GetStream();

            // Send the encoded string to the server
            ns.Write(byteBuffer, 0, byteBuffer.Length);

            //Response.Write("Sent {0} bytes to server..." + byteBuffer.Length);
            ns.Flush();

            // Receive the same string back from the server
            byte[] data = new byte[2048];


            System.Threading.Thread.Sleep(5000);
            int recv = ns.Read(data, 0, data.Length);
            //Response.Write("Received {0} bytes from server: {1}" + totalBytesRcvd +
            String reply = Encoding.ASCII.GetString(data, 0, recv);

            //ns.Close();
            //client.Close();

            return reply;
        }
        catch (Exception e)
        {
            return "error";
            //Response.Write(e.Message);
        }
        finally
        {

        }
    }
}