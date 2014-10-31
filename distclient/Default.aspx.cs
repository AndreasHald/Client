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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        String url = Request.QueryString["activityID"];
        if (url != null)
        {
            // CREATE ACTIVITY SPECIFIC TEMPLATE IF URL STRING
            createactivity();
        }
        else
        {
            // CREATES TABLE USING MyTemplate
            int week = 1;
            createtable(week);
        }
        //user u = new user();
        //encryption crypt = new encryption();
        //connection conn = new connection();
        
        //u.overallID = "logIn";
        //u.email = "admin@admin.dk";
        //u.password = "d6YSr320JnLXlp8YYxUcNQ==";
        //u.isAdmin = false;

        //String jsonstring = JsonConvert.SerializeObject(u);

        //String output = crypt.EncryptDecrypt(jsonstring);
        
        
        //Response.Write(conn.connect(output));


        
    }

    public void createactivity()
    {
        rweek.HeaderTemplate = new ActivityTemplate(ListItemType.Header);
        rweek.ItemTemplate = new ActivityTemplate(ListItemType.Item);
        rweek.FooterTemplate = new ActivityTemplate(ListItemType.Footer);

        DataTable dt = new DataTable("mydt");
        dt.Columns.Add("day", typeof(string));
        dt.Columns.Add("date", typeof(int));
        dt.Columns.Add("time", typeof(int));
        dt.Rows.Add(new string[3] { "Monday", "1", "8" });

        rweek.DataSource = dt;
        rweek.DataBind();
    }

    public class ActivityTemplate : System.Web.UI.ITemplate
    {
        System.Web.UI.WebControls.ListItemType templateType;
        public ActivityTemplate(System.Web.UI.WebControls.ListItemType type)
        {
            templateType = type;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            PlaceHolder ph = new PlaceHolder();
            switch (templateType)
            {
                case ListItemType.Header:
                    ph.Controls.Add(new LiteralControl("<div id='specevent'>"));
                    ph.Controls.Add(new LiteralControl("<ul>"));
                    break;
                case ListItemType.Item:
                    // PRINT EVENT SPECIFIC FUNCTIONS
                    ph.Controls.Add(new LiteralControl("<li>"));
                    ph.Controls.Add(new LiteralControl("Lecture:"));
                    ph.Controls.Add(new LiteralControl("</li>"));
                    ph.Controls.Add(new LiteralControl("<li>"));
                    ph.Controls.Add(new LiteralControl("Virksomhedens Økonomiske Styring (3)"));
                    ph.Controls.Add(new LiteralControl("</li>"));
                    ph.Controls.Add(new LiteralControl("<li>"));
                    ph.Controls.Add(new LiteralControl("Location: SP212"));
                    ph.Controls.Add(new LiteralControl("</li>"));
                    break;
                case ListItemType.Footer:
                    ph.Controls.Add(new LiteralControl("</ul>"));
                    ph.Controls.Add(new LiteralControl("</div>"));
                    break;
            }
            container.Controls.Add(ph);
        }
    }

    public void createtable(int week)
    {
        rweek.HeaderTemplate = new MyTemplate(ListItemType.Header);
        rweek.ItemTemplate = new MyTemplate(ListItemType.Item);
        rweek.FooterTemplate = new MyTemplate(ListItemType.Footer);

        rweek1.HeaderTemplate = new MyTemplate(ListItemType.Header);
        rweek1.ItemTemplate = new MyTemplate(ListItemType.Item);
        rweek1.FooterTemplate = new MyTemplate(ListItemType.Footer);

        DataTable dt = new DataTable("mydt");
        dt.Columns.Add("day", typeof(string));
        dt.Columns.Add("date", typeof(int));
        dt.Columns.Add("time", typeof(int));
        dt.Rows.Add(new string[3] { "Monday", "1", "8" });

        rweek.DataSource = dt;
        rweek.DataBind();

        rweek1.DataSource = dt;
        rweek1.DataBind();

        


    }

    public class MyTemplate : System.Web.UI.ITemplate
    {
        System.Web.UI.WebControls.ListItemType templateType;
        public MyTemplate(System.Web.UI.WebControls.ListItemType type)
        {
            templateType = type;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
   
            PlaceHolder ph = new PlaceHolder();
            string host = HttpContext.Current.Request.Url.AbsolutePath;
            List<String> days = new List<string>();
            days.Add("Monday");
            days.Add("Tuesday");
            days.Add("Wednesday");
            days.Add("Thursday");
            days.Add("Friday");
            days.Add("Saturday");
            days.Add("Sunday");

            List<String> times = new List<string>();
            times.Add("8:00");
            times.Add("9:00");
            times.Add("10:00");
            times.Add("11:00");
            times.Add("12:00");
            times.Add("13:00");
            times.Add("14:00");
            times.Add("15:00");
            times.Add("16:00");
            times.Add("17:00");
            times.Add("18:00");

            switch (templateType)
            {
                case ListItemType.Header:
                    ph.Controls.Add(new LiteralControl("<table class='calstyle'>"));
                    ph.Controls.Add(new LiteralControl("<th class='rowheader' colspan='8'>"));
                    
                    ph.Controls.Add(new LiteralControl(Convert.ToString(GetWeekNo(Gettoday()))));

                    ph.Controls.Add(new LiteralControl("</th>"));
                    ph.Controls.Add(new LiteralControl("<tr class='row'>"));
                    ph.Controls.Add(new LiteralControl("<td>"));
                    ph.Controls.Add(new LiteralControl("<a id='click'>Week View</a>"));
                    ph.Controls.Add(new LiteralControl("</td>"));
                    for (int i = 0; i < days.Count; i++)
                    {
                        ph.Controls.Add(new LiteralControl("<td>"));
                        ph.Controls.Add(new LiteralControl(daysfromtoday(days[i])));
                        ph.Controls.Add(new LiteralControl("<br />"));
                        ph.Controls.Add(new LiteralControl(days[i]));
                        
                        ph.Controls.Add(new LiteralControl("</td>"));
                    }
                    ph.Controls.Add(new LiteralControl("</tr>"));
                    break;
                case ListItemType.Item:

                    for (int o = 0; o < times.Count; o++)
                    {
                        ph.Controls.Add(new LiteralControl("<tr class='row'>"));
                        for (int i = 0; i < 8; i++)
                        {
                            if (i == 0)
                            {
                                ph.Controls.Add(new LiteralControl("<td class='ctime'>"));
                                ph.Controls.Add(new LiteralControl(times[o]));
                            }
                            else
                            {
                            // GET EVENTS
                                ph.Controls.Add(new LiteralControl("<td>"));
                                // i = DAY o = TIME
                                if (i == 3 && o==3)
                                {
                                    ph.Controls.Add(new LiteralControl("<div class='event'>"));
                                    ph.Controls.Add(new LiteralControl("<a href='"+ host + "?activityID=" + "1" + "'>"));
                                    ph.Controls.Add(new LiteralControl("Lecture"));
                                    ph.Controls.Add(new LiteralControl("<br />"));
                                    ph.Controls.Add(new LiteralControl("VØS 3"));
                                    ph.Controls.Add(new LiteralControl("</a>"));
                                    ph.Controls.Add(new LiteralControl("</div>"));
                                }
                                else
                                {
                                    ph.Controls.Add(new LiteralControl("..."));

                                }
                            }
                            ph.Controls.Add(new LiteralControl("</td>"));

                        }
                        ph.Controls.Add(new LiteralControl("</tr>"));
                    }
                    break;
                case ListItemType.Footer:
                    ph.Controls.Add(new LiteralControl("</table>"));
                    break;
            }
            container.Controls.Add(ph);
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


        public String daysfromtoday(String days)
        {
            DateTime today = DateTime.Today;

            //CultureInfo myCulture = new CultureInfo("da-DK");
            //myCulture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            //System.Threading.Thread.CurrentThread.CurrentCulture = myCulture;

                switch(days)
                {
                    case "Monday":
                        return DateTime.Today.AddDays((DayOfWeek.Monday - today.DayOfWeek)).ToString("dd");
                    case "Tuesday":
                        return DateTime.Today.AddDays((DayOfWeek.Tuesday - today.DayOfWeek)).ToString("dd");
                    case "Wednesday":
                        return DateTime.Today.AddDays((DayOfWeek.Wednesday - today.DayOfWeek)).ToString("dd");
                    case "Thursday":
                        return DateTime.Today.AddDays((DayOfWeek.Thursday - today.DayOfWeek)).ToString("dd");
                    case "Friday":
                        return DateTime.Today.AddDays((DayOfWeek.Friday - today.DayOfWeek)).ToString("dd");
                    case "Saturday":
                        return DateTime.Today.AddDays((DayOfWeek.Saturday - today.DayOfWeek)).ToString("dd");
                    case "Sunday":
                        return DateTime.Today.AddDays(((DayOfWeek.Sunday - today.DayOfWeek)+7)).ToString("dd");
                    default:
                        return "error";
                }
    
            }
        }

}

