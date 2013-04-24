using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return date.AddDays(1 - date.Day);
        }

        public static DayOfWeek FirstWeekDayOfMonth(this DateTime date)
        {
            return date.FirstDayOfMonth().DayOfWeek;
        }

        public static int DaysInMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.DaysInMonth());
        }

        public static DayOfWeek LastWeekDayOfMonth(this DateTime date)
        {
            return date.LastDayOfMonth().DayOfWeek;
        }
        
        public static int WeeksInMonth(this DateTime date)
        {
            return (int)Math.Ceiling(((int)date.FirstWeekDayOfMonth() + date.DaysInMonth()) / 7.0);
        }
        
    }
}