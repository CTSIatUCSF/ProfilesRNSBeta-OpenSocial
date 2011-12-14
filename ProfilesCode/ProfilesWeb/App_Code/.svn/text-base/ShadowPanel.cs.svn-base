using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
/// Summary description for Box
/// </summary>
///
namespace System.Web.UI.WebControls
{
    public class ShadowPanel : Panel
    {
        public ShadowPanel()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            CssClass = CssClass.Length > 0 ? "shadowPanel " + CssClass : "shadowPanel";

            base.RenderBeginTag(writer);

            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, Width.Value + "px");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "top");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "right");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();

            writer.RenderEndTag();

            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, Width.Value + "px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, Height.Value - 40 + "px");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, Height.Value - 40 + "px");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();

            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, Width.Value - 40 + "px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, Height.Value - 40 + "px");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "center");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();

            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, Height.Value - 40 + "px");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "right");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();

            writer.RenderEndTag();

            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, Width.Value + "px");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "bottom");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "right");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.RenderEndTag();

            writer.RenderEndTag();

            base.RenderEndTag(writer);
        }
    }
}
