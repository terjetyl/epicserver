using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MiniCms.Web.Code.ExtensionMethods
{
    public static class LabelExtensions
    {
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString SmartLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return LabelHelper(html,
                               ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                               ExpressionHelper.GetExpressionText(expression));
        }

        public static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName)
        {
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            var tag = new TagBuilder("label");
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);

            if (metadata.IsRequired)
            {
                var spanTag = new TagBuilder("span");
                spanTag.Attributes.Add("class", "required");
                spanTag.SetInnerText("*");

                return MvcHtmlString.Create(string.Format("{0} {1}", tag.ToString(TagRenderMode.Normal), spanTag.ToString(TagRenderMode.Normal)));
            }

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}