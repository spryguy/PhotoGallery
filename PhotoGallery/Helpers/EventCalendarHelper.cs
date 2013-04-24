using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HtmlTags;
using HtmlTags.Extensions;
using HtmlTags.Foundation;
using PhotoGallery.Extensions;
using PhotoGallery.HtmlTags.Extensions;

namespace PhotoGallery.Helpers
{
    //MONTH VIEW:
    /*As a consumer I want to be able to view the default event page or see a calendar display of events past, present and future that I can view by month, week or day. (1) 
        ●	Allow transition forward or backward by month, week or day (1)
     * this is where a read only month view (with nav) comes in handy.  don't worry about week view for now.
     */
    //all views (except month view): events do not display past the "expiration" date.  (defaults to midnight day of event)
    //event view: wrapper div, ul, li's per event, maybe an article and <address>.  background image?  thumbnail?
    //real simple - don't need a full blown calendar.
    //Current/Next Event (homepage): responsive event details?
    //featured event: responsive event details that are marked as featured.
    //event detail: a page that has the full event details
    public static class EventCalendarHelper
    {
        public static MvcHtmlString EventCalendar(this HtmlHelper htmlHelper, List<Event> events)
        {
            var dtf = CultureInfo.CurrentCulture.DateTimeFormat;
            DateTime today = DateTime.Now;

            var wrapper = Tags.Div.AddClass("calendar");

            var navUl = Tags.UL.AddClass("month-browser").Append(
                new List<HtmlTag>
                    {
                        Tags.ListItem.AddClass("calendar_nav").Append(new AnchorTag().Href("#", new LiteralTag(String.Format("{0}  {1}", "&laquo;", today.AddMonths(-1).ToString("MMMM"))))),
                        Tags.ListItem.AddClass("current-month").Append(new TimeTag(today).Text(today.ToString("MMMM yyyy"))),
                        Tags.ListItem.AddClass("calendar_nav").Append(new AnchorTag().Href("#", new LiteralTag(String.Format("{0}  {1}", today.AddMonths(1).ToString("MMMM"), "&raquo;"))))

                    });

            var weekdaysUl = Tags.UL.AddClass("weekdays");

            foreach (var day in Enum.GetNames(typeof(DayOfWeek)))
            {
                weekdaysUl.Append(Tags.ListItem.Text(day));
            }

            var monthUl = Tags.UL.AddClass("month");

            //start rendering li's at the date of the first day of the month - day of week
            var firstDaytoRender = today.FirstDayOfMonth().AddDays(-(int)today.FirstWeekDayOfMonth());
            var lastDayToRender = today.LastDayOfMonth().AddDays(6 - (int)today.LastWeekDayOfMonth());

            var dayToRender = firstDaytoRender;
            while (dayToRender <= lastDayToRender.AddDays(1))   //need to add 1 to get the last day
            {
                //render
                var li = Tags.ListItem;
                //is it a fillerDay?
                if (dayToRender.Month != today.Month)
                {
                    li.AddClass("filler");
                }

                //does the day have events?
                if (!events.Any(x => dayToRender.Equals(x.StartDate)))
                {
                    li.AddClass("empty");
                }

                li.AddClass("day");
                li.Append(new TimeTag(dayToRender.Date).Append(
                        new List<HtmlTag>
                            {
                                Tags.Span.AddClass("day-name").Text(String.Format("{0}, ", dtf.GetDayName(dayToRender.DayOfWeek))),
                                Tags.Span.AddClass("month-name").Text(dtf.GetMonthName(dayToRender.Month))
                            }
                    ).Text(dayToRender.Day.ToString(CultureInfo.InvariantCulture)));

                //render todays events
                foreach (var e in events.Where(x => dayToRender.Equals(x.StartDate)))
                {
                    li.Append(
                        Tags.Article.Append(
                            Tags.Header.Append(new LinkTag(e.Title, "#", "event-title"))
                            )
                            .Append(
                                new TimeTag(dayToRender.Date).AddClass("event-time")
                                                             .Text(e.StartDate.ToShortTimeString()))
                            .Append(Tags.Address.Text(e.Location))
                        );



                    /*<article>
                    <header><a href="http://www.atlantaballet.com/tickets-performances/carmina-burana/" class="event-title">David Bintley&#8217;s Carmina Burana</a></header>
                    <time datetime="2013-05-03" class="event-time">8:00 pm</time>
                    <address>
                        Harley Davidson Museum<br />
                        444-4444
                    </address>
                    <div class="event-text">at the Cobb Energy Performing Arts Centre</div>
                </article>*/
                }

                monthUl.Append(li);

                //increment
                dayToRender = dayToRender.AddDays(1);
            }
            var row = Tags.Div.AddClass(Foundation3.Classes.Row).Append(
                wrapper.Append(new List<HtmlTag>
                    {
                        navUl,
                        weekdaysUl,
                        monthUl
                    })
                );

            return MvcHtmlString.Create(row.ToPrettyString());
        }
    }


}

public class Event
{
    public Event(string title, string eventAbstract, string description, DateTime startDate, string location, DateTime endDate, Uri thumbnailUri)
    {
        Title = title;
        Abstract = eventAbstract;
        Description = description;
        StartDate = startDate;
        Location = location;
        EndDate = endDate;
        ThumbnailUri = thumbnailUri;
    }


    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Uri ThumbnailUri { get; set; }
    public string Location { get; set; }
    public string Title { get; set; }
    public string Abstract { get; set; }
    public string Description { get; set; }
}

/*
<div class="row">
    <div class="calendar">
        <ul class="month-browser">
            <li class="calendar_nav"><a href="/calendar/2013-03/">&laquo;  @DateTime.Now.AddMonths(-1).ToString("MMMM")</a></li>
            <li id="current-month">
                <time datetime="@DateTime.Now.ToShortDateString()">@DateTime.Now.ToString("MMMM yyyy")</time>
            </li>
            <li class="calendar_nav"><a href="/calendar/2013-05/">@DateTime.Now.AddMonths(1).ToString("MMMM")  &raquo;</a></li>
        </ul>
        <ul class="weekdays">
            @{
                foreach (var day in Enum.GetNames(typeof(DayOfWeek)))
                {
                <li>@day</li>
                }
            }

        </ul>

        <ul class="month">
            <li class="filler day">
                <time datetime="2013-05-03"><span class="day-name">Wed,</span> <span class="month-name">Apr </span>31</time>
            </li>
            <li class="empty day">
                <time datetime="2013-05-03"><span class="day-name">Wed,</span> <span class="month-name">Apr </span>1</time>
            </li>
            <li class="empty day">
                <time datetime="2013-05-03"><span class="day-name">Wed,</span> <span class="month-name">Apr </span>2</time>
                gobbledy gook text
            </li>
            <li class="empty day">
                <div class="date day_cell"><span class="day-name">Wed,</span> <span class="month-name">Apr</span> 3</div>
            </li>
            <li class="day">
                <time datetime="2013-05-03"><span class="day-name">Thurs,</span> <span class="month-name">Apr </span>4</time>
                <article>
                    <header><a href="http://www.atlantaballet.com/tickets-performances/carmina-burana/" class="event-title">David Bintley&#8217;s Carmina Burana</a></header>
                    <time datetime="2013-05-03" class="event-time">8:00 pm</time>
                    <address>
                        Harley Davidson Museum<br />
                        444-4444
                    </address>
                    <div class="event-text">at the Cobb Energy Performing Arts Centre</div>
                </article>

            </li>
*/