using System;

namespace HtmlTags.Extensions
{
    public class ImageTag : HtmlTag
    {
        public ImageTag()
            : base("img")
        {

        }

        public ImageTag Src(string source)
        {
            Attr("src", source);
            return this;
        }
        public ImageTag(string source, string caption, bool useDataCaption = false)
            : base("img")
        {
            Attr("src", source);
            Attr("alt", caption);
            Attr("title", caption);
            if (useDataCaption) Data("caption", caption);
        }

        public string Src()
        {
            return Attr("src");
        }

        public ImageTag Alt(string alt)
        {
            Attr("alt", alt);
            return this;
        }

        public string Alt()
        {
            return HasAttr("alt") ? Attr("alt") : "";
        }
    }
}