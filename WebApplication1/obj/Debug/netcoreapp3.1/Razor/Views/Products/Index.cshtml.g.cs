#pragma checksum "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92f830ab563887ea6f4a13c27d4d3c79b46ae086"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92f830ab563887ea6f4a13c27d4d3c79b46ae086", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"637209e7eeedf13d00f2cccd93a350b795d01eb6", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShoppingCart.Application.ViewModels.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Index</h1>\n\n<p>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92f830ab563887ea6f4a13c27d4d3c79b46ae0863794", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</p>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 16 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 19 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 22 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 25 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 28 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ImageUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 31 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Stock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 37 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 40 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 43 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n");
#nullable restore
#line 46 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
                  var description = System.Net.WebUtility.HtmlDecode(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("               <span>");
#nullable restore
#line 47 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
                Write(description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                \n            </td>\n            <td>\n                ");
#nullable restore
#line 51 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n");
#nullable restore
#line 54 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
                  var path = "/pictures/" + item.ImageUrl; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n               <img");
            BeginWriteAttribute("src", " src=\"", 1456, "\"", 1467, 1);
#nullable restore
#line 56 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
WriteAttributeValue("", 1462, path, 1462, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n            </td>\n            <td>\n                ");
#nullable restore
#line 59 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Stock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 62 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new {  id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 63 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 64 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 67 "C:\Users\micxu\Source\Repos\Assignment-SecuringApps_SWD6.2A\WebApplication1\Views\Products\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShoppingCart.Application.ViewModels.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
