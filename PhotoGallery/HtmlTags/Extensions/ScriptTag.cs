namespace HtmlTags.Extensions
{
    public class ScriptTag : HtmlTag
    {
        public ScriptTag(string javascript)
            : base("script")
        {
            Attr("type", "text/javascript");
            Text(javascript);
        }
    }
}