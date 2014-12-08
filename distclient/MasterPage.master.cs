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
        login l = new login();

        string usr = txtuser.Text;
        string pass = txtpass.Text;
        if(l.authenticate(usr, pass))
        {
            Session["username"] = usr;
            Session["password"] = pass;

            Response.Redirect(host);
        }
        else
        {
            Response.Write("you are not logged in");
        }       
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
        else { cal.publicOrPrivate = 0; cal.sharedto = " "; }

        createCalendar CC = new createCalendar();

        CC.cc(cal);
    }

    public void populate()
    {
        string userid = Session["userID"].ToString();
        quot q = new quot();
        q.overallID = "getQuote";
        getQuote gq = new getQuote();
        var quo = JsonConvert.DeserializeObject<quot>((gq.gQ(q)));
        Quoteotd.Text = "Quote: " + quo.quote + "Author: " + quo.author;

        getCalendar gc = new getCalendar();
        getEvent ge = new getEvent();
        getNote gn = new getNote();
        var Cal = JsonConvert.DeserializeObject<List<calendar>>(gc.dc(userid));
        

        if (Cal.Count > 0)
        { 

            for (int i = 0; i < Cal.Count; i++ )
            {
                var item = new ListItem
                {
                    Text = Cal[i].calenderName,
                    Value = Cal[i].CalendarID
                };
                deleteCalendarName.Items.Add(item);
                createEventCalendar.Items.Add(item);
            }
        
            customevents e = new customevents();
            e.overallID = "getEventInfo";
            for (int o = 0; o < Cal.Count; o++)
            { 
                e.CalenderID = Cal[o].CalendarID;
                var Events = JsonConvert.DeserializeObject<List<customevents>>(ge.getEvents(e));

                if (Events.Count > 0)
                {
                        var item = new ListItem
                        {
                            Text = Events[o].name,
                            Value = Events[o].eventid
                        };
                        deleteEventName.Items.Add(item);
                        createNoteEvents.Items.Add(item);
                }
                note n = new note();
                n.overallID = "getNote";
                
                for (int a = 0; a < Events.Count; a++)
                {
                    n.eventid = Events[a].eventid;
                    var Notes = JsonConvert.DeserializeObject<List<note>>(gn.gn(n));
                    
                    if (Notes.Count>0)
                    { 
                        var item = new ListItem
                        {
                            Text = Notes[a].noteText,
                            Value = Notes[a].noteId
                        };

                        deleteNoteName.Items.Add(item);

                    }
                }
            }
            
        }
        else
        {
            var item = new ListItem
            {
                Text = "None found"
            };
            deleteCalendarName.Items.Add(item);
            createEventCalendar.Items.Add(item);
            deleteEventName.Items.Add(item);
            createNoteEvents.Items.Add(item);
            deleteNoteName.Items.Add(item);
        }
    }

    protected void deleteCalendarExecute_Click(object sender, EventArgs e)
    {
        calendar dc = new calendar();

        dc.overallID = "deleteCalender";
        dc.calenderName = deleteCalendarName.SelectedItem.ToString();
        dc.userName = Session["username"].ToString();

        deleteCalendar delete = new deleteCalendar();

        delete.dc(dc);
    }
    protected void deleteEventExecute_Click(object sender, EventArgs e)
    {
        customevents ce = new customevents();
        deleteEvent de = new deleteEvent();
        ce.overallID = "deleteEvent";
        ce.eventid = deleteEventName.SelectedValue.ToString();

        de.dE(ce);

    }
    protected void createNoteExecute(object sender, EventArgs e)
    {
        note cn = new note();
        createNote cnn = new createNote();

        cn.overallID = "saveNote";
        cn.noteText = createNoteText.Text;
        cn.noteCreatedBy = Session["username"].ToString();
        cn.eventid = createNoteEvents.SelectedValue.ToString();

        cnn.cE(cn);
    }
    protected void deleteNoteExecute(object sender, EventArgs e)
    {
        note dn = new note();
        deleteNote dnn = new deleteNote();

        dn.overallID = "deleteNote";
        dn.noteId = deleteNoteName.SelectedValue.ToString();

        dnn.deleteN(dn);
    }
}
