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


public class week1template : System.Web.UI.ITemplate
{
        System.Web.UI.WebControls.ListItemType templateType;
        public week1template(System.Web.UI.WebControls.ListItemType type)
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
                    ph.Controls.Add(new LiteralControl("<td class='ccell'>"));
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
                                ph.Controls.Add(new LiteralControl("<td class='ctime' width='5%'>"));
                                ph.Controls.Add(new LiteralControl(times[o]));
                            }
                            else
                            {
                            // GET EVENTS
                                
                                ph.Controls.Add(new LiteralControl("<td class='ccell' width='13.5%'>"));
                                // i = DAY o = TIME
                                //string json = "{ 'events': [{'activityid':'BINTO1051U_LA_E14','eventid':'BINTO1051U_LA_E14_9ec39e04ed4cde6c77e9dad2791ec065_a2b2d1448f89a42f4abcadb195f5baa5','type':'Lecture','title':'BINTO1051U.LA_E14','description':'Virksomhedens \u00f8konomiske styring (3) (LA)','start':['2014',11,'13','8','00'],'end':['2014',11,'14','9','40'],'location':'SPs14'},{'activityid':'BINTO1051U_LA_E14','eventid':'BINTO1051U_LA_E14_f2608aef8ea5cefc3b4e4661e8a1b65a_6f97eb60f5ac86a8bd6bd40e15bc21df','type':'Lecture','title':'BINTO1051U.LA_E14','description':'Virksomhedens \u00f8konomiske styring (3) (LA)','start':['2014',8,'12','8','00'],'end':['2014',8,'12','9','40'],'location':'SPs14'},{'activityid':'BINTO1051U_LA_E14','eventid':'BINTO1051U_LA_E14_358e537c3b8bc9ba3a777151fe0dbe84_46ecada33c30f1809f39cf3de0c32188','type':'Lecture','title':'BINTO1051U.LA_E14','description':'Virksomhedens \u00f8konomiske styring (3) (LA)','start':['2014',8,'19','8','00'],'end':['2014',8,'19','9','40'],'location':'SPs14'},{'activityid':'BINTO1051U_LA_E14','eventid':'BINTO1051U_LA_E14_c419aa6aa104d33cb5a9f95bd0e80fdc_26a862c80fdd0194eee0789c9824f71c','type':'Lecture','title':'BINTO1051U.LA_E14','description':'Virksomhedens \u00f8konomiske styring (3) (LA)','start':['2014',8,'26','8','00'],'end':['2014',8,'26','11','30'],'location':'SPs08 Nykredit Aud.'}]}";
                                getEvent ge = new getEvent();

                                string json = new WebClient().DownloadString("http://calendar.cbs.dk/events.php/anha13ao/c69e9c9423e1154d9eea09b9a02a6a91.json)");
                                
                                ESObject0 obj = JsonConvert.DeserializeObject<ESObject0>(json);
                                for (int g = 0; g < obj.events.Count(); g++)
                                {
                                    string y = obj.events[g].start[0];
                                    string m = obj.events[g].start[1];
                                    string d = obj.events[g].start[2];

                                    // MÅNED                         // DATO                         // TIDSPUNKT                                // VIRKER IKKE FOR 2 CIFRE          
                                    if (obj.events[g].start[1].Equals(Convert.ToString(GetMonth())) && i == Int32.Parse(determine(obj.events[g].start[0], obj.events[g].start[1], obj.events[g].start[2])) && obj.events[g].start[3].Equals(times[o].Substring(0, 1)))
                                    {
                                        ph.Controls.Add(new LiteralControl("<div class='event'>"));
                                        ph.Controls.Add(new LiteralControl("<a href='" + host + "?activityID=" + obj.events[g].eventid + "'>"));
                                        ph.Controls.Add(new LiteralControl("<div class='eventtime'>" + obj.events[g].start[3] + ":" + obj.events[g].start[4] + "-" + obj.events[g].end[3] + ":" + obj.events[g].end[4] + "</div> <br />"));
                                        ph.Controls.Add(new LiteralControl(obj.events[g].description + "<hr />"));
                                        ph.Controls.Add(new LiteralControl("Location: " + obj.events[g].location + "<br />"));
                                        ph.Controls.Add(new LiteralControl(obj.events[g].type + "<br />"));
                                        ph.Controls.Add(new LiteralControl("</a>"));
                                        ph.Controls.Add(new LiteralControl("</div>"));
                                    }
                               }
                                ph.Controls.Add(new LiteralControl("..."));
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
        
        public int GetMonth()
        {
            DateTime month = DateTime.Now;
            return month.Month;
        }

        public bool checkweek(string y, string m, string d)
        {
            int year = Int32.Parse(y);
            int month = Int32.Parse(m);
            int day = Int32.Parse(d);
            DateTime value;
            value = new DateTime(year, month, day);
            if (GetWeekNo(Gettoday()) == GetWeekNo(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public string determine(string y, string m, string d)
        {
            int year = Int32.Parse(y);
            int month = Int32.Parse(m);
            int day = Int32.Parse(d);
            DateTime value = new DateTime(year, month, day);
            return value.DayOfWeek.ToString("d");
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
                        return DateTime.Today.AddDays(7 +((DayOfWeek.Sunday - today.DayOfWeek))).ToString("dd");
                    default:
                        return "error";
                }
    
            }
        }

