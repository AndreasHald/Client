﻿using System;
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
using System.Threading.Tasks;


public class week1template : System.Web.UI.ITemplate
{
        System.Web.UI.WebControls.ListItemType templateType;
        public week1template(System.Web.UI.WebControls.ListItemType type)
        {
            templateType = type;
        }
        public int add = -28;
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
            times.Add("19:00");
            times.Add("20:00");
            times.Add("21:00");
            times.Add("22:00");

            List<String> colours = new List<string>();
            colours.Add("#fbcf61");
            colours.Add("#ff6f6f");
            colours.Add("#3498db");
            colours.Add("#a8d164");
            colours.Add("#b23f73");
            colours.Add("#48647c");
            colours.Add("#0dccc0");
            colours.Add("#832d51");
            colours.Add("#e84b3a");
            colours.Add("#c0392b");

            switch (templateType)
            {
                case ListItemType.Header:
                    ph.Controls.Add(new LiteralControl("<div class='week'>"+ Convert.ToString(GetWeekNo(Gettoday(add)))+"</div>"));
                    ph.Controls.Add(new LiteralControl("<div class='calendarbody'>"));
                    ph.Controls.Add(new LiteralControl("<div class='timebody'>"));
                    ph.Controls.Add(new LiteralControl("<div class='time'><a id='click'>Week View</a></div>"));
                    for (int i = 0; i < times.Count; i++ )
                    {
                        ph.Controls.Add(new LiteralControl("<div class='time'>" + times[i] + "</div>"));
                    }
                    ph.Controls.Add(new LiteralControl("</div>"));
    
                    break;
                case ListItemType.Item:
                    string userid = HttpContext.Current.Session["userID"].ToString();

                    getCalendar gc = new getCalendar();
                    getEvent ge = new getEvent();
                    getNote gn = new getNote();
                    

                        
                    customevents ce = new customevents();
                    ce.overallID = "getEventInfo";
                    ce.CalenderID = "1";

                    // ARRAYS

                    var Cal = JsonConvert.DeserializeObject<List<calendar>>(gc.dc(userid));
                    ESObject0 obj = ge.getCBSEvents();
                    var Events = JsonConvert.DeserializeObject<List<customevents>>(ge.getEvents(ce));    
                        
                    for (int o = 0; o < days.Count; o++)
                    {
                        ph.Controls.Add(new LiteralControl("<div class='weekdaybody'>"));

                        //GET EVENTS
                        
                        List<String> type = new List<String>();

                        int y;
                        int m;
                        int d;

                        int sh;
                        int sm;

                        int eh;
                        int em;

                        int startpos;
                        int endpos;
                        int duration;

                            for (int e = 0; e < obj.events.Count(); e++)
                            {
                                y = Int32.Parse(obj.events[e].start[0]);
                                m = Int32.Parse(obj.events[e].start[1]);
                                d = Int32.Parse(obj.events[e].start[2]);

                                if (checkweek(y, m, d, o))
                                {

                                    sh = Int32.Parse(obj.events[e].start[3]);
                                    sm = Int32.Parse(obj.events[e].start[4]);

                                    eh = Int32.Parse(obj.events[e].end[3]);
                                    em = Int32.Parse(obj.events[e].end[4]);

                                    startpos = ((sh - 8) * 60) + sm + 60;
                                    endpos = ((eh - 8) * 60) + em + 60;
                                    duration = endpos - startpos;

                                    ph.Controls.Add(new LiteralControl("<div class='event' style='top:" + startpos + "px;" + " height:" + duration + "px; background-color:" + colours[8] + ";'>"));
                                    ph.Controls.Add(new LiteralControl("<a href='" + host + "?activityID=" + obj.events[e].eventid + "'>"));
                                    ph.Controls.Add(new LiteralControl("<div class='eventtime'>" + obj.events[e].start[3] + ":" + obj.events[e].start[4] + "-" + obj.events[e].end[3] + ":" + obj.events[e].end[4] + "</div> <br />"));
                                    ph.Controls.Add(new LiteralControl(obj.events[e].description + "<br /><br />"));
                                    ph.Controls.Add(new LiteralControl("Location: " + obj.events[e].location + "<br />"));
                                    ph.Controls.Add(new LiteralControl(obj.events[e].type + "<br />"));
                                    ph.Controls.Add(new LiteralControl("</a>"));
                                    ph.Controls.Add(new LiteralControl("</div>"));
                                }
                                    
                            }
                        ph.Controls.Add(new LiteralControl("<div class='weekday no-bg'>" + days[o] + "<br /><span class='date'>" + daysfromtoday(days[o]) + "</span></div"));
                        for (int t = 0; t <= times.Count; t++)
                        {
                            ph.Controls.Add(new LiteralControl("<div class='weekday'></div>"));
                        }
                        ph.Controls.Add(new LiteralControl("</div>"));
                    }

                    break;
                case ListItemType.Footer:
                    ph.Controls.Add(new LiteralControl("</div>"));
                    break;
            }
            container.Controls.Add(ph);
        }

        public DateTime date;
        public DateTime value;
        public DateTime today;

        public List<String> removedupes(List<String> type)
        {
            type.Sort();
            Int32 index = 0;
            while (index < type.Count - 1)
            {
                if (type[index] == type[index + 1])
                    type.RemoveAt(index);
                else
                    index++;
            }
            return type;
        }
        
        public DateTime Gettoday(int add)
        {
            date = DateTime.Now.AddDays(add);
            return date;
        }

        public bool checkweek(int y, int m, int d, int o)
        {
            try
            {
                value = new DateTime(y, m, d);
            }
            catch
            {
                return false;
            }
                
            if (GetWeekNo(Gettoday(add)) == GetWeekNo(value) && o == Int32.Parse((value.DayOfWeek.ToString("d"))))
            {
                System.Diagnostics.Debug.WriteLine("sucess");
                return true;
            }
            else
            {
                return false;
            }
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
            today = DateTime.Today;

            //CultureInfo myCulture = new CultureInfo("da-DK");
            //myCulture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            //System.Threading.Thread.CurrentThread.CurrentCulture = myCulture;

                switch(days)
                {
                    case "Monday":
                        return DateTime.Today.AddDays(add + (DayOfWeek.Monday - today.DayOfWeek)).ToString("dd");
                    case "Tuesday":
                        return DateTime.Today.AddDays(add + (DayOfWeek.Tuesday - today.DayOfWeek)).ToString("dd");
                    case "Wednesday":
                        return DateTime.Today.AddDays(add + (DayOfWeek.Wednesday - today.DayOfWeek)).ToString("dd");
                    case "Thursday":
                        return DateTime.Today.AddDays(add + (DayOfWeek.Thursday - today.DayOfWeek)).ToString("dd");
                    case "Friday":
                        return DateTime.Today.AddDays(add + (DayOfWeek.Friday - today.DayOfWeek)).ToString("dd");
                    case "Saturday":
                        return DateTime.Today.AddDays(add + (DayOfWeek.Saturday - today.DayOfWeek)).ToString("dd");
                    case "Sunday":
                        return DateTime.Today.AddDays(add+7 +((DayOfWeek.Sunday - today.DayOfWeek))).ToString("dd");
                    default:
                        return "error";
                }
    
            }
        }

