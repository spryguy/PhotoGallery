using PhotoGallery.HtmlTags.Extensions;

namespace HtmlTags.Extensions
{
    public static class Tags
    {
        public static HtmlTag Div
        {
            get { return new DivTag(); }
        }

        public static HtmlTag UL
        {
            get { return new HtmlTag("ul"); }
        }

        public static HtmlTag H1
        {
            get { return new HtmlTag("h1"); }
        }

        public static HtmlTag H2
        {
            get { return new HtmlTag("h2"); }
        }

        public static HtmlTag H3
        {
            get { return new HtmlTag("h3"); }
        }

        public static HtmlTag PTag
        {
            get { return new HtmlTag("p"); }
        }

        public static HtmlTag ListItem
        {
            get { return new HtmlTag("li"); }
        }

        public static HtmlTag Anchor
        {
            get { return new AnchorTag(); }
        }

        public static HtmlTag Image
        {
            get { return new ImageTag(); }
        }

        public static HtmlTag Time
        {
            get { return new TimeTag(); }
        }

        public static HtmlTag Article
        {
            get { return new HtmlTag("article"); }
        }
        public static HtmlTag Header
        {
            get { return new HtmlTag("header"); }
        }

        public static HtmlTag Span
        {
            get { return new HtmlTag("span"); }
        }

        public static HtmlTag Address
        {
            get { return new HtmlTag("address"); }
        }
    }
}