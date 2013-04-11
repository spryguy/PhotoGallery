using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HtmlTags;
using HtmlTags.Extensions;

namespace PhotoGallery.Helpers
{

    public class FetauredInventory
    {
        public string Url { get; set; }
        public string ImageUri { get; set; }
        public string ThumbnailUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
    }

    public static class FeatureHelper
    {
        public static MvcHtmlString FeatureSlider(this HtmlHelper htmlHelper, List<FetauredInventory> items)
        {
            //li/span/href/img/span
            var ul = Tags.UL.Id("features").AddClass("slides");

            foreach (var item in items)
            {
                var container = Tags.Div;
                container.Append(
                    Tags.Div.Text(item.Description)
                    )
                         .Append(
                             new AnchorTag().Href(item.Url, new ImageTag(item.Url, item.Description, true))
                    )
                         .Append(
                             Tags.Div.Text(item.Price.ToString("C"))
                    );

                ul.Append(Tags.ListItem.Append(container));
            }

            return MvcHtmlString.Create(Tags.Div.AddClasses("flexslider", "carousel").Append(ul).ToHtmlString());
            //return MvcHtmlString.Create(Tags.Div.AddClass("flexslider").Append(ul).ToHtmlString());
        }
    }
}
