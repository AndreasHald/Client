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
using System.Threading.Tasks;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String url = Request.QueryString["activityID"];
        if (url != null)
        {
            // CREATE ACTIVITY SPECIFIC TEMPLATE IF URL STRING
            Session["activityID"] = url;
            createactivity();
        }
        else
        {

            // REWORK LOGIN
            if (Session["username"] != null && Session["password"] != null)
            {
                createtable();        
            }
           
        }
        



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
            getEvent ge = new getEvent();

            ESObject0 obj = ge.getCBSEvents();
            string host = HttpContext.Current.Request.Url.AbsolutePath;
            _Default d = new _Default();
            string u = Convert.ToString(d.Session["activityID"]);
            PlaceHolder ph = new PlaceHolder();
            switch (templateType)
            {
                case ListItemType.Header:
                    ph.Controls.Add(new LiteralControl("<center id='specevent'>"));
                    ph.Controls.Add(new LiteralControl("<ul>"));
                    break;
                case ListItemType.Item:
                    // PRINT EVENT SPECIFIC FUNCTIONS
                    for (int g = 0; g < obj.events.Count(); g++)
                    {
                        if (obj.events[g].eventid.Equals(u))
                        {
                            ph.Controls.Add(new LiteralControl("<li>"));
                            ph.Controls.Add(new LiteralControl("Type: " + obj.events[g].type));
                            ph.Controls.Add(new LiteralControl("</li>"));
                            ph.Controls.Add(new LiteralControl("<li>"));
                            ph.Controls.Add(new LiteralControl("ID: " + obj.events[g].eventid));
                            ph.Controls.Add(new LiteralControl("</li>"));
                            ph.Controls.Add(new LiteralControl("<li>"));
                            ph.Controls.Add(new LiteralControl("Title: " + obj.events[g].description));
                            ph.Controls.Add(new LiteralControl("</li>"));
                            ph.Controls.Add(new LiteralControl("<li>"));
                            ph.Controls.Add(new LiteralControl("Location: " + obj.events[g].location));
                            ph.Controls.Add(new LiteralControl("</li>"));
                            ph.Controls.Add(new LiteralControl("<li>"));
                            ph.Controls.Add(new LiteralControl("Start Time: " + obj.events[g].start[0] + " " + obj.events[g].start[2] + "/"+ obj.events[g].start[1] + " " + obj.events[g].start[3] + ":" +   obj.events[g].start[4]));
                            ph.Controls.Add(new LiteralControl("</li>"));
                            ph.Controls.Add(new LiteralControl("<li>"));
                            ph.Controls.Add(new LiteralControl("End Time: " + obj.events[g].end[0] + " " +  obj.events[g].end[2] + "/" + obj.events[g].end[1] + " " + obj.events[g].end[3] + ":" + obj.events[g].end[4]));
                            ph.Controls.Add(new LiteralControl("</li>"));
                        }
                    }
                    break;
                case ListItemType.Footer:
                    ph.Controls.Add(new LiteralControl("</ul>"));
                    ph.Controls.Add(new LiteralControl("<br /> <a href='' onclick='goBack()'>Back</a>"));
                    ph.Controls.Add(new LiteralControl("</center>"));
                    break;
            }
            container.Controls.Add(ph);
        }
    }

    public void createtable()
    {
        rweek.HeaderTemplate = new week1template(ListItemType.Header);
        rweek.ItemTemplate = new week1template(ListItemType.Item);
        rweek.FooterTemplate = new week1template(ListItemType.Footer);

        rweek1.HeaderTemplate = new week2template(ListItemType.Header);
        rweek1.ItemTemplate = new week2template(ListItemType.Item);
        rweek1.FooterTemplate = new week2template(ListItemType.Footer);

        rweek2.HeaderTemplate = new week3template(ListItemType.Header);
        rweek2.ItemTemplate = new week3template(ListItemType.Item);
        rweek2.FooterTemplate = new week3template(ListItemType.Footer);

        DataTable dt = new DataTable("mydt");
        dt.Columns.Add("1", typeof(int));
        dt.Columns.Add("2", typeof(int));
        dt.Columns.Add("3", typeof(int));
        dt.Columns.Add("4", typeof(int));
        dt.Rows.Add(new string[4] { "1", "1", "1", "1" });

        rweek.DataSource = dt;
        rweek.DataBind();

        rweek1.DataSource = dt;
        rweek1.DataBind();

        rweek2.DataSource = dt;
        rweek2.DataBind();

        


    }
}
