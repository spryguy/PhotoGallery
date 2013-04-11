using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HtmlTags;
using HtmlTags.Extensions;
using HtmlTags.Foundation;

namespace PhotoGallery.Helpers
{
    public class Image
    {
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Caption { get; set; }
    }

    public static class PhotoGalleryHelper
    {
        public static MvcHtmlString PhotoGallery(this HtmlHelper htmlHelper, List<Image> images)
        {

            var ul = Tags.UL.Id("gallery").AddClasses(Foundation3.GetBlockGridColumnsCss(4, 2));
            ul.Data(Foundation3.Attributes.Clearing, "");
            //ul.Attr("data-clearing");
            foreach (var image in images)
            {
                ul.Append(Tags.ListItem.Append(new AnchorTag().Href(image.Url, new ImageTag(image.Url, image.Caption, true))));
            }

            var row = new DivTag().AddClass(Foundation3.Classes.Row)
                        .Append(
                            Tags.Div.AddClass(Foundation3.GetColumnsCss(12, true))
                                .Append(Tags.Div.Append(
                                            new List<HtmlTag>
                                            {
                                                Tags.H2.Text("put configuration.title here"),
                                                Tags.H3.Text("configuration.Date.ToShortDateString()"),
                                                Tags.PTag.Text("configuration.Description")

                                            }
                                        )
                                )
                                .Append(ul)
                        )
                        .After(new ScriptTag("/dx1/Content/Scripts/Libs/foundation/jquery.event.move.js"))
                        .Append(new ScriptTag("/dx1/Content/Scripts/Libs/foundation/jquery.event.swipe.js"))
                        .Append(new ScriptTag("/dx1/Content/Scripts/Libs/foundation/jquery.foundation.clearing.js"))
                        .Append(new ScriptTag("/dx1/Content/Scripts/Libs/foundation/jquery.foundation.mediaQueryToggle.js"))
                        .Append(new ScriptTag("/dx1/Content/Scripts/Libs/foundation/jquery.foundation.orbit.js"))
                        .Append(new ScriptTag("/dx1/Content/Scripts/Libs/foundation/app.js"))
                        .Append(new StyleLink("/dx1/Content/Modules/photoGallery/Css/photoGallery.css"));

            return MvcHtmlString.Create(row.ToString());
        }

    }


}
