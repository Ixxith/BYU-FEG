using BYU_FEG.Models;
using BYU_FEG.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BYU_FEG.Infrastructure
{

    //Creates a TagHelper to help with pagination in the website 

    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        // Uses a local model - PagingInfo to build the PageModel
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        // Set up Dictionary for handling PageUrlValue classes
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }


        // TagHelper that increments to match total pages from PagingInfo and creates links that match page numbers
        // This is then appended to the html
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPage; i++)
            {

                // If we are using a page filter, we will build a form to post the current filter rather than using a url. I am sure there is an easier way to generate this, 
                // but unable to do so due to time constraints

                if (PageModel.filter != null)
                {

                    TagBuilder form = new TagBuilder("form");
                    form.Attributes["asp-action"] = "Data";
                    form.Attributes["method"] = "post";


                    TagBuilder tag = new TagBuilder("button");

                    TagBuilder input = new TagBuilder("input");
                    input.Attributes["Type"] = "hidden";
                    input.Attributes["Name"] = "page";
                    input.Attributes["Value"] = i.ToString();
                    form.InnerHtml.AppendHtml(input);

                    TagBuilder i2 = new TagBuilder("input");
                    i2.Attributes["Type"] = "hidden";
                    i2.Attributes["Name"] = "burial";
                    i2.Attributes["Value"] = PageModel.filter.burial.ToString();


                    TagBuilder i3 = new TagBuilder("input");
                    i3.Attributes["Type"] = "hidden";
                    i3.Attributes["Name"] = "burialdepth";
                    i3.Attributes["Value"] = PageModel.filter.burialdepth.ToString();

                    TagBuilder i4 = new TagBuilder("input");
                    i4.Attributes["Type"] = "hidden";
                    i4.Attributes["Name"] = "burialsituation";
                    i4.Attributes["Value"] = PageModel.filter.burialsituation;

                    TagBuilder i5 = new TagBuilder("input");
                    i5.Attributes["Type"] = "hidden";
                    i5.Attributes["Name"] = "datefoundbegin";
                    i5.Attributes["Value"] = PageModel.filter.datefoundbegin.ToString();


                    TagBuilder i6 = new TagBuilder("input");
                    i6.Attributes["Type"] = "hidden";
                    i6.Attributes["Name"] = "datefoundend";
                    i6.Attributes["Value"] = PageModel.filter.datefoundend.ToString();

                    TagBuilder i7 = new TagBuilder("input");
                    i7.Attributes["Type"] = "hidden";
                    i7.Attributes["Name"] = "estimatedage";
                    i7.Attributes["Value"] = PageModel.filter.estimatedage.ToString();

                    TagBuilder i8 = new TagBuilder("input");
                    i8.Attributes["Type"] = "hidden";
                    i8.Attributes["Name"] = "estimatedheight";
                    i8.Attributes["Value"] = PageModel.filter.estimatedheight.ToString();

                    TagBuilder i9 = new TagBuilder("input");
                    i9.Attributes["Type"] = "hidden";
                    i9.Attributes["Name"] = "gender";
                    i9.Attributes["Value"] = PageModel.filter.gender;

                    TagBuilder i10 = new TagBuilder("input");
                    i10.Attributes["Type"] = "hidden";
                    i10.Attributes["Name"] = "haircolor";
                    i10.Attributes["Value"] = PageModel.filter.haircolor;

                    TagBuilder i11 = new TagBuilder("input");
                    i11.Attributes["Type"] = "hidden";
                    i11.Attributes["Name"] = "hasartifact";
                    i11.Attributes["Value"] = PageModel.filter.hasartifact;

                    TagBuilder i12 = new TagBuilder("input");
                    i12.Attributes["Type"] = "hidden";
                    i12.Attributes["Name"] = "headdirection";
                    i12.Attributes["Value"] = PageModel.filter.headdirection;

                    TagBuilder i13 = new TagBuilder("input");
                    i13.Attributes["Type"] = "hidden";
                    i13.Attributes["Name"] = "itemtaken";
                    i13.Attributes["Value"] = PageModel.filter.itemtaken;

                    TagBuilder i14 = new TagBuilder("input");
                    i14.Attributes["Type"] = "hidden";
                    i14.Attributes["Name"] = "lengthofremains";
                    i14.Attributes["Value"] = PageModel.filter.lengthofremains.ToString();

                    form.InnerHtml.AppendHtml(i2);
                    form.InnerHtml.AppendHtml(i3);
                    form.InnerHtml.AppendHtml(i4);
                    form.InnerHtml.AppendHtml(i5);
                    form.InnerHtml.AppendHtml(i6);
                    form.InnerHtml.AppendHtml(i7);
                    form.InnerHtml.AppendHtml(i8);
                    form.InnerHtml.AppendHtml(i9);
                    form.InnerHtml.AppendHtml(i10);
                    form.InnerHtml.AppendHtml(i11);
                    form.InnerHtml.AppendHtml(i12);
                    form.InnerHtml.AppendHtml(i13);
                    form.InnerHtml.AppendHtml(i14);


                    tag.InnerHtml.Append(i.ToString());
                    //Add some classes to improve look of links
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        // If it's the current page, highlight the button by adding a Bootstrap class
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }
                    form.InnerHtml.AppendHtml(tag);

                    result.InnerHtml.AppendHtml(form);
                } 
                else
                {
                    TagBuilder tag = new TagBuilder("a");

                    PageUrlValues["page"] = i;


                    tag.Attributes["href"] = "/home/data" + urlHelper.Action(PageAction, PageUrlValues);
                    tag.InnerHtml.Append(i.ToString());
                    //Add some classes to improve look of links
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        // If it's the current page, highlight the button by adding a Bootstrap class
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    result.InnerHtml.AppendHtml(tag);
                }
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
