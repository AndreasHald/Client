using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime today = default(DateTime);
        today = DateTime.Now;

        Cal.SelectedDate = today;
        Cal.VisibleDate = today;
    }

    protected void Cal_SelectionChanged(object sender, EventArgs e)
    {
        selected.Text = "Du har valgt:";
        selected.Text += Cal.SelectedDate;
    }

    public static int Week(System.DateTime date)
    {
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        System.Globalization.Calendar Cal = ci.Calendar;
        System.Globalization.CalendarWeekRule cwr = ci.DateTimeFormat.CalendarWeekRule;
        DayOfWeek dow = ci.DateTimeFormat.FirstDayOfWeek;
        return Cal.GetWeekOfYear(date, cwr, dow);
    }
    protected void Cal_DayRender(object sender, DayRenderEventArgs e)
    {
        if (Week(e.Day.Date) != Week(Cal.SelectedDate))
        {
            e.Cell.Text = "";
        }
    }
    protected void Cal_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
     // NÅR MÅNEDEN ÆNDRES
    }
}