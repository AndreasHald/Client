using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadevents();

        DateTime date = Gettoday();
        
        // LOAD WEEKS
        int week = GetWeekNo(Gettoday());
        int week1 = week + 1;
        int week2 = week1 + 1;
        labelweek0.Text = Convert.ToString(week);
        labelweek1.Text = Convert.ToString(week1);
        labelweek2.Text = Convert.ToString(week2);

        // LOAD DATES

        loaddates();
        
        // OLD loadevents();

        String eventtype = "Lecture";
        String eventdiscription = "Virksomhedens \u00f8konomiske styring (3)";
        //week0mon.Text = Convert.ToString(DateTime.Today.DayOfWeek);

        eventtest.Text = "<div class='event'>";
        eventtest.Text += eventdiscription;
        eventtest.Text += "<br />";
        eventtest.Text += eventtype;

    }
   
    public DateTime Gettoday()
    {
        DateTime date = DateTime.Now;
        return date;
    }

    public int GetWeekNo(DateTime date)
    {
        System.Globalization.CultureInfo cult_info = System.Globalization.CultureInfo.CreateSpecificCulture("da-DA  ");
        System.Globalization.Calendar cal = cult_info.Calendar;
        int weekNo = cal.GetWeekOfYear(date, cult_info.DateTimeFormat.CalendarWeekRule, cult_info.DateTimeFormat.FirstDayOfWeek);
        return weekNo;
    }

    public void loaddates()
    {
        String today = Convert.ToString(DateTime.Today.DayOfWeek);

        int date = Gettoday().Day;
        int month = DateTime.Today.Month;
        int year = DateTime.Today.Year;
        int dim = System.DateTime.DaysInMonth(year, month);
        
        // DAYS UNTILL END OF MONTH
        int dl = dim % date;
        
        if (today == ("Monday") || today.Equals("Monday"))
        {
            week0mon.Text = DateTime.Today.ToString("dd");
            week0tue.Text = DateTime.Today.AddDays(1).ToString("dd");
            week0wed.Text = DateTime.Today.AddDays(2).ToString("dd");
            week0thur.Text = DateTime.Today.AddDays(3).ToString("dd");
            week0fri.Text = DateTime.Today.AddDays(4).ToString("dd");
            week0sat.Text = DateTime.Today.AddDays(5).ToString("dd");
            week0sun.Text = DateTime.Today.AddDays(6).ToString("dd");
            week1mon.Text = DateTime.Today.AddDays(7).ToString("dd");
            week1tue.Text = DateTime.Today.AddDays(8).ToString("dd");
            week1wed.Text = DateTime.Today.AddDays(9).ToString("dd");
            week1thur.Text = DateTime.Today.AddDays(10).ToString("dd");
            week1fri.Text = DateTime.Today.AddDays(11).ToString("dd");
            week1sat.Text = DateTime.Today.AddDays(12).ToString("dd");
            week1sun.Text = DateTime.Today.AddDays(13).ToString("dd");
            
        }
        else if (today == ("Tuesday") || today.Equals("Tuesday"))
        {
            week0mon.Text = DateTime.Today.AddDays(-1).ToString("dd");
            week0tue.Text = DateTime.Today.ToString("dd");
            week0wed.Text = DateTime.Today.AddDays(1).ToString("dd");
            week0thur.Text = DateTime.Today.AddDays(2).ToString("dd");
            week0fri.Text = DateTime.Today.AddDays(3).ToString("dd");
            week0sat.Text = DateTime.Today.AddDays(4).ToString("dd");
            week0sun.Text = DateTime.Today.AddDays(5).ToString("dd");
            week1mon.Text = DateTime.Today.AddDays(6).ToString("dd");
            week1tue.Text = DateTime.Today.AddDays(7).ToString("dd");
            week1wed.Text = DateTime.Today.AddDays(8).ToString("dd");
            week1thur.Text = DateTime.Today.AddDays(9).ToString("dd");
            week1fri.Text = DateTime.Today.AddDays(10).ToString("dd");
            week1sat.Text = DateTime.Today.AddDays(11).ToString("dd");
            week1sun.Text = DateTime.Today.AddDays(12).ToString("dd");
        }
        else if (today == ("Wednesday") || today.Equals("Wednesday"))
        {
            week0mon.Text = DateTime.Today.AddDays(-2).ToString("dd");
            week0tue.Text = DateTime.Today.AddDays(-1).ToString("dd");
            week0wed.Text = DateTime.Today.ToString("dd");
            week0thur.Text = DateTime.Today.AddDays(1).ToString("dd");
            week0fri.Text = DateTime.Today.AddDays(2).ToString("dd");
            week0sat.Text = DateTime.Today.AddDays(3).ToString("dd");
            week0sun.Text = DateTime.Today.AddDays(4).ToString("dd");
            week1mon.Text = DateTime.Today.AddDays(5).ToString("dd");
            week1tue.Text = DateTime.Today.AddDays(6).ToString("dd");
            week1wed.Text = DateTime.Today.AddDays(7).ToString("dd");
            week1thur.Text = DateTime.Today.AddDays(8).ToString("dd");
            week1fri.Text = DateTime.Today.AddDays(9).ToString("dd");
            week1sat.Text = DateTime.Today.AddDays(10).ToString("dd");
            week1sun.Text = DateTime.Today.AddDays(11).ToString("dd");
        }
        else if (today == ("Thursday") || today.Equals("Thursday"))
        {
            week0mon.Text = DateTime.Today.AddDays(-3).ToString("dd");
            week0tue.Text = DateTime.Today.AddDays(-2).ToString("dd");
            week0wed.Text = DateTime.Today.AddDays(-1).ToString("dd");
            week0thur.Text = DateTime.Today.ToString("dd");
            week0fri.Text = DateTime.Today.AddDays(1).ToString("dd");
            week0sat.Text = DateTime.Today.AddDays(2).ToString("dd");
            week0sun.Text = DateTime.Today.AddDays(3).ToString("dd");
            week1mon.Text = DateTime.Today.AddDays(4).ToString("dd");
            week1tue.Text = DateTime.Today.AddDays(5).ToString("dd");
            week1wed.Text = DateTime.Today.AddDays(6).ToString("dd");
            week1thur.Text = DateTime.Today.AddDays(7).ToString("dd");
            week1fri.Text = DateTime.Today.AddDays(8).ToString("dd");
            week1sat.Text = DateTime.Today.AddDays(9).ToString("dd");
            week1sun.Text = DateTime.Today.AddDays(10).ToString("dd");

        }
        else if (today == ("Friday") || today.Equals("Friday"))
        {
            week0mon.Text = DateTime.Today.AddDays(-4).ToString("dd");
            week0tue.Text = DateTime.Today.AddDays(-3).ToString("dd");
            week0wed.Text = DateTime.Today.AddDays(-2).ToString("dd");
            week0thur.Text = DateTime.Today.AddDays(-1).ToString("dd");
            week0fri.Text = DateTime.Today.ToString("dd");
            week0sat.Text = DateTime.Today.AddDays(1).ToString("dd");
            week0sun.Text = DateTime.Today.AddDays(2).ToString("dd");
            week1mon.Text = DateTime.Today.AddDays(3).ToString("dd");
            week1tue.Text = DateTime.Today.AddDays(4).ToString("dd");
            week1wed.Text = DateTime.Today.AddDays(5).ToString("dd");
            week1thur.Text = DateTime.Today.AddDays(6).ToString("dd");
            week1fri.Text = DateTime.Today.AddDays(7).ToString("dd");
            week1sat.Text = DateTime.Today.AddDays(8).ToString("dd");
            week1sun.Text = DateTime.Today.AddDays(9).ToString("dd");

        }
        else if (today == ("Saturday") || today.Equals("Saturday"))
        {
            week0mon.Text = DateTime.Today.AddDays(-5).ToString("dd");
            week0tue.Text = DateTime.Today.AddDays(-4).ToString("dd");
            week0wed.Text = DateTime.Today.AddDays(-3).ToString("dd");
            week0thur.Text = DateTime.Today.AddDays(-2).ToString("dd");
            week0fri.Text = DateTime.Today.AddDays(-1).ToString("dd");
            week0sat.Text = DateTime.Today.ToString("dd");
            week0sun.Text = DateTime.Today.AddDays(1).ToString("dd");
            week1mon.Text = DateTime.Today.AddDays(2).ToString("dd");
            week1tue.Text = DateTime.Today.AddDays(3).ToString("dd");
            week1wed.Text = DateTime.Today.AddDays(4).ToString("dd");
            week1thur.Text = DateTime.Today.AddDays(5).ToString("dd");
            week1fri.Text = DateTime.Today.AddDays(6).ToString("dd");
            week1sat.Text = DateTime.Today.AddDays(7).ToString("dd");
            week1sun.Text = DateTime.Today.AddDays(8).ToString("dd");
        }
        else if (today == ("Sunday") || today.Equals("Sunday"))
        {
            week0mon.Text = DateTime.Today.AddDays(-6).ToString("dd");
            week0tue.Text = DateTime.Today.AddDays(-5).ToString("dd");
            week0wed.Text = DateTime.Today.AddDays(-4).ToString("dd");
            week0thur.Text = DateTime.Today.AddDays(-3).ToString("dd");
            week0fri.Text = DateTime.Today.AddDays(-2).ToString("dd");
            week0sat.Text = DateTime.Today.AddDays(-1).ToString("dd");
            week0sun.Text = DateTime.Today.ToString("dd");
            week1mon.Text = DateTime.Today.AddDays(1).ToString("dd");
            week1tue.Text = DateTime.Today.AddDays(2).ToString("dd");
            week1wed.Text = DateTime.Today.AddDays(3).ToString("dd");
            week1thur.Text = DateTime.Today.AddDays(4).ToString("dd");
            week1fri.Text = DateTime.Today.AddDays(5).ToString("dd");
            week1sat.Text = DateTime.Today.AddDays(6).ToString("dd");
            week1sun.Text = DateTime.Today.AddDays(7).ToString("dd");
   
        }
    }


    public class events
    {
        [JsonProperty("activityid")]
        public string activityid { get; set; }

        [JsonProperty("eventid")]
        public string eventid { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("lecture")]
        public string lecture { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }
    }

    public void loadevents()
    {
        for(int i = 1; i <= 10; i++)
        {
            Literal l = Page.FindControl(string.Format("Label{0}", i)) as Literal
            if(l != null)
            l.Text = "Whatever";
        }
    }

    public void loadeventsOLD()
    {
        string url = "https//calendar.cbs.dk/events.php/anha13ao/c69e9c9423e1154d9eea09b9a02a6a91.json";

        using (var w = new WebClient())
        {
            var data = string.Empty;
            try
            {
                data = w.DownloadString(url);
            }
            catch (Exception)
            {

            }
            var result = JsonConvert.DeserializeObject<events>(data);

            events e = new events();
        }
    }

    
}