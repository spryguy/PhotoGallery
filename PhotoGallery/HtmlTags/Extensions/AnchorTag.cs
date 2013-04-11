using System;

namespace HtmlTags.Extensions
{
    public class AnchorTag : HtmlTag
    {
        public AnchorTag()
            : base("a")
        {
        }

        public AnchorTag(Action<HtmlTag> configure)
            : base("a", configure)
        {
        }

        public AnchorTag Href(string address)
        {
            Attr("href", address);
            return this;
        }

        public AnchorTag Href(Uri address, HtmlTag innerTag)
        {
            return Href(address.ToString(), innerTag);
        }
        public AnchorTag Href(string address, HtmlTag innerTag)
        {
            Attr("href", address);
            Append(innerTag);
            return this;
        }

        public AnchorTag OnClick(string javascript)
        {
            Attr("onclick", javascript);
            return this;
        }
    }
}