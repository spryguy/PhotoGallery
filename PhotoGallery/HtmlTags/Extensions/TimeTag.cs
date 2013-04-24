using System;
using HtmlTags;

namespace PhotoGallery.HtmlTags.Extensions
{
    public class TimeTag : HtmlTag
    {
        public TimeTag(): base("time"){}

        public TimeTag(DateTime dateTime) : base("time")
        {
            Attr("datetime", dateTime.ToShortDateString());
        }

        public TimeTag DateAttribute(DateTime dateTime)
        {
            Attr("datetime", dateTime.ToShortDateString());
            return this;
        }
        
    }
}