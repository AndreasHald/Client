using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for @event
/// </summary>
/// 

public class events
{
    public List<string> eve { get; set; }
    public String overallID { get; set; }
    public String activityid { get; set; }
    public String eventid { get; set; }
    public String type { get; set; }
    public String title { get; set; }
    public String description { get; set; }
    public String location { get; set; }
    public String createdby { get; set; }
    public List<string> start { get; set; }
    public List<string> end { get; set; }
    public String CalendarID { get; set; }

}

public class ESObject0
{
    [JsonProperty("events")]
    public List<events> events { get; set; }
}