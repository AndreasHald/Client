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
        if (Session["username"] != null && Session["password"] != null)
        {
            CurrentUser.Text = "You are logged in as: " + Session["username"];
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
        customevents ce = new customevents();

        ce.overallID = "createEvent";

        ce.type = createEventType.SelectedValue;
        ce.location = createEventLocation.Text;
        ce.createdby = Session["userID"].ToString();
        ce.startTime = createEventStartYear.SelectedValue.ToString() +"-" + createEventStartMonth.SelectedValue.ToString() + "-" + createEventStartDay.SelectedItem.ToString() + " " + createEventStartTime.Text;
        ce.endTime = createEventStartYear.SelectedValue.ToString() +"-" + createEventStartMonth.SelectedValue.ToString() + "-" + createEventStartDay.SelectedItem.ToString() + " " + createEventEndTime.Text;
        ce.name = createEventName.Text;
        ce.text = createEventDescription.Text;
        ce.customevent = "0";
        ce.CalenderID = createEventCalendar.SelectedValue.ToString();

        createEvent createevent = new createEvent();
        createevent.ce(ce);

    }

    protected void createCalendar(object sender, EventArgs e)
    {
        calendar cal = new calendar();
        cal.overallID = "createCalender";
        cal.calenderName = createCalendarName.Text;
        cal.userName = Session["username"].ToString();
        if (createCalendarSharedYes.Checked == true)
        { 
            cal.publicOrPrivate = 1;
            cal.sharedto = createCalendarSharedUser.Text;
        }
        else { cal.publicOrPrivate = 0; }

        createCalendar CC = new createCalendar();

        CC.cc(cal);
    }

    public void populate()
    {
        string userid = Session["userID"].ToString();
        getCalendar gc = new getCalendar();
        var Cal = JsonConvert.DeserializeObject<List<calendar>>(gc.dc(userid));
        //calendar c = JsonConvert.DeserializeObject<calendar>(gc.dc(userid));

        for (int i = 0; i < 5; i++ )
        {
            var item = new ListItem
            {
                Text = Cal[i].calenderName,
                Value = Cal[i].CalendarID
            };
            deleteCalendarName.Items.Add(item);
            createEventCalendar.Items.Add(item);
        }
            
    }

    protected void deleteCalendarExecute_Click(object sender, EventArgs e)
    {
        calendar dc = new calendar();

        dc.overallID = "deleteCalender";
        dc.calenderName = deleteCalendarName.SelectedValue.ToString();
        dc.userName = Session["username"].ToString();
    }
}
