using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for model_calendar
/// </summary>
public class calendar
{
    public String overallID { get; set; }
    public String calenderName { get; set; }
    public String CalendarID { get; set; }
    public String userName { get; set; }
    public String sharedto { get; set; }
    public int publicOrPrivate { get; set; }
}