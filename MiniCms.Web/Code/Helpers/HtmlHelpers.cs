using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MiniCms.Web.Code.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString MenuLink(
    this HtmlHelper htmlHelper,
    string linkText,
    string actionName,
    string controllerName
)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            if (controllerName == currentController && actionName == currentAction)
            {
                return htmlHelper.ActionLink(
                    linkText,
                    actionName,
                    controllerName,
                    null,
                    new
                    {
                        @class = "current"
                    });
            }
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string imagepath, string title = "")
        {
            return Image(helper, imagepath, title, 0, 0);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string imagepath, string title = "", int width = 0)
        {
            return Image(helper, imagepath, title, width, 0);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string imagepath, string title = "", int width = 0, int height = 0)
        {
            var urlHelper = ((Controller)helper.ViewContext.Controller).Url;
            var photoUrl = urlHelper.Action("Render", "Images", new { file = imagepath, width, height });
            var img = new TagBuilder("img");
            img.MergeAttribute("src", photoUrl);
            img.MergeAttribute("title", title);
            img.MergeAttribute("alt", title);
            return new MvcHtmlString(img.ToString());
        }

        public static MvcHtmlString Pager(this HtmlHelper helper, int currentPage, int pageSize, int totalItemCount, object routeValues)
        {
            var pagerHelper = new PagerHelper(currentPage, pageSize, totalItemCount, 10);

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var query = helper.ViewContext.RequestContext.HttpContext.Request["q"];
            string queryString = !string.IsNullOrEmpty(query) ? "&q=" + query : string.Empty;
            var container = new TagBuilder("div");
            container.AddCssClass("pager");
            var actionName = helper.ViewContext.RouteData.GetRequiredString("Action");

            // if we are past the first page  	
            if (currentPage > 1)
            {
                var previous = new TagBuilder("a");
                previous.SetInnerText("<");
                previous.AddCssClass("previous");
                var routingValues = new RouteValueDictionary(routeValues);
                routingValues.Add("page", currentPage - 1);
                previous.MergeAttribute("href", urlHelper.Action(actionName, routingValues) + queryString);
                container.InnerHtml += previous.ToString();
            }

            // if we have past the first page group  	
            if (currentPage > pagerHelper.GroupSize)
            {
                var previousDots = new TagBuilder("a");
                previousDots.SetInnerText("...");
                previousDots.AddCssClass("previous-dots");
                var routingValues = new RouteValueDictionary(routeValues);
                routingValues.Add("page", pagerHelper.GroupStart - pagerHelper.GroupSize);
                previousDots.MergeAttribute("href", urlHelper.Action(actionName, routingValues) + queryString);
                container.InnerHtml += previousDots.ToString();
            }

            for (var i = pagerHelper.GroupStart; i <= pagerHelper.GroupEnd; i++)
            {
                var pageNumber = new TagBuilder("a");
                pageNumber.AddCssClass(((i == pagerHelper.CurrentPage)) ? "selected-page" : "page");
                pageNumber.SetInnerText((i).ToString());
                var routingValues = new RouteValueDictionary(routeValues);
                routingValues.Add("page", i);
                pageNumber.MergeAttribute("href", urlHelper.Action(actionName, routingValues) + queryString);
                container.InnerHtml += pageNumber.ToString();
            }

            // if there are still pages past the end of this page group  	
            if (pagerHelper.PageCount > pagerHelper.GroupEnd)
            {
                var nextDots = new TagBuilder("a");
                nextDots.SetInnerText("...");
                nextDots.AddCssClass("next-dots");
                var routingValues = new RouteValueDictionary(routeValues);
                routingValues.Add("page", pagerHelper.GroupEnd + 1);
                nextDots.MergeAttribute("href", urlHelper.Action(actionName, routingValues) + queryString);
                container.InnerHtml += nextDots.ToString();
            }

            // if we still have pages left to show  	
            if (pagerHelper.CurrentPage < pagerHelper.PageCount)
            {
                var next = new TagBuilder("a");
                next.SetInnerText(">");
                next.AddCssClass("next");
                var routingValues = new RouteValueDictionary(routeValues);
                routingValues.Add("page", currentPage + 1);
                next.MergeAttribute("href", urlHelper.Action(actionName, routingValues) + queryString);
                container.InnerHtml += next.ToString();
            }

            return MvcHtmlString.Create(container.ToString());
        }
    }

    public class PagerHelper
    {
        private readonly int _currentPage;
        private readonly int _pageSize;
        private readonly int _totalCount;
        private readonly int _groupSize;

        public PagerHelper(int currentPage, int pageSize, int totalCount, int groupSize)
        {
            _currentPage = currentPage;
            _pageSize = pageSize;
            _totalCount = totalCount;
            _groupSize = groupSize;
        }

        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(_totalCount / (double)_pageSize);
            }
        }

        public int CurrentPage
        {
            get
            {
                if (_currentPage < 1)
                    return 1;
                if (_currentPage > PageCount)
                    return PageCount;
                return _currentPage;
            }
        }

        public int FirstPage
        {
            get { return 1; }
        }

        public int LastPage
        {
            get { return PageCount; }
        }

        public int GroupEnd
        {
            get
            {
                // calculate the last page group number starting from the current page  	
                // until we hit the next whole divisible number  	
                var lastGroupNumber = CurrentPage;
                while ((lastGroupNumber % _groupSize != 0)) lastGroupNumber++;

                // correct if we went over the number of pages  	
                return Math.Min(lastGroupNumber, PageCount);
            }
        }

        public int GroupStart
        {
            get
            {
                return Math.Max(GroupEnd - _groupSize + 1, 1);
            }
        }

        public int GroupSize { get { return _groupSize; } }
    }
}