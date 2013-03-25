namespace HtmlTags.Extensions
{
    public class StyleLink : HtmlTag
    {
        public StyleLink(string styleSource)
            : base("link")
        {
            Attr("href", styleSource);
            Attr("rel", "stylesheet");
            Attr("type", "text/css");
            NoClosingTag();
        }
    }
}