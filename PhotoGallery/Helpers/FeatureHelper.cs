using System.Collections.Generic;
using System.Web.Mvc;
using HtmlTags;
using HtmlTags.Extensions;

namespace PhotoGallery.Helpers
{

    public class FetauredItem
    {
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }

    public static class FeatureHelper
    {
        public static MvcHtmlString FeatureSlider(this HtmlHelper htmlHelper, List<FetauredItem> items)
        {
            //li/span/href/img/span
            var ul = Tags.UL.Id("features").AddClass("slides");
            
            foreach (var item in items)
            {
                ul.Append(Tags.ListItem.Append(
                    new HtmlTag("div").Text(item.Description)
                              )
                              .Append(new AnchorTag().Href(item.Url, new ImageTag(item.Url, item.Description, true))
                              )
                              .Append(new HtmlTag("div").Text(item.Price)
                              )
                    );
            }

            return MvcHtmlString.Create(Tags.Div.AddClasses("flexslider", "carousel").Append(ul).ToHtmlString());
        }
    }
}
