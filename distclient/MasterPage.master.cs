using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Session["userID"]);
        if (Session["username"] != null && Session["password"] != null)
        {
            start.Visible = false;
            functions.Visible = true;

            populate();
        }
        else
        {
            start.Visible = true;
            functions.Visible = false;
        }
    }
    protected void login(object sender, EventArgs e)
    {
        string host = HttpContext.Current.Request.Url.AbsolutePath;

        string usr = txtuser.Text;
        string pass = txtpass.Text;

        Session["username"] = usr;
        Session["password"] = pass;

        Response.Redirect(host);


    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Remove("username");
        Session.Remove("password");
    }
    protected void createEvent(object sender, EventArgs e)
    {

    }

    public void populate()
    {
        string userid = Session["userID"].ToString();
        getCalendar gc = new getCalendar();

        calendar c = JsonConvert.DeserializeObject<calendar>(gc.dc(userid));

        for (int i = 0; i < 5; i++ )
        {
            var item = new ListItem
            {
                Text = c.calenderName,
                Value = c.CalendarID
            };
            createEventCalendar.Items.Add(item);
        }
            
    }
}
