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
    }
}