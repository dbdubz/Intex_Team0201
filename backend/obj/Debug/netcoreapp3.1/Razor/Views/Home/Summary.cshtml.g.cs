#pragma checksum "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\Home\Summary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07c49841579f0a2e9b5a872b3af6efeeaaf1eba2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Summary), @"mvc.1.0.view", @"/Views/Home/Summary.cshtml")]
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
#line 1 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\_ViewImports.cshtml"
using backend.Components;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07c49841579f0a2e9b5a872b3af6efeeaaf1eba2", @"/Views/Home/Summary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d386dae4d5b5c9240c51794f067e9111f115723", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Summary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BurialViewModel>
    #nullable disable
    {
        private global::AspNetCore.Views_Home_Summary.__Generated__SexViewComponentTagHelper __SexViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "BurialSummary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-action", "Summary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class", "btn", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-normal", "btn-outline-dark", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-selected", "btn-primary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-group pull-right m-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::backend.Infrastructure.PaginationTagHelper __backend_Infrastructure_PaginationTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<div className=\"container\">\r\n    <div className=\"col-4\">\r\n        <div className=\"border\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:Sex", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07c49841579f0a2e9b5a872b3af6efeeaaf1eba25959", async() => {
            }
            );
            __SexViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_Home_Summary.__Generated__SexViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__SexViewComponentTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div className=\"col\">\r\n");
#nullable restore
#line 13 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\Home\Summary.cshtml"
     foreach(Burialmain b in Model.Burialmains)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "07c49841579f0a2e9b5a872b3af6efeeaaf1eba27161", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 15 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\Home\Summary.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = b;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\Home\Summary.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07c49841579f0a2e9b5a872b3af6efeeaaf1eba28925", async() => {
            }
            );
            __backend_Infrastructure_PaginationTagHelper = CreateTagHelper<global::backend.Infrastructure.PaginationTagHelper>();
            __tagHelperExecutionContext.Add(__backend_Infrastructure_PaginationTagHelper);
#nullable restore
#line 18 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\Home\Summary.cshtml"
__backend_Infrastructure_PaginationTagHelper.PageModel = Model.PageInfo;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __backend_Infrastructure_PaginationTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __backend_Infrastructure_PaginationTagHelper.PageAction = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __backend_Infrastructure_PaginationTagHelper.PageClass = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __backend_Infrastructure_PaginationTagHelper.PageClassNormal = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __backend_Infrastructure_PaginationTagHelper.PageClassSelected = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 19 "C:\Users\sdcab\Source\Repos\Intex_Team0201\backend\Views\Home\Summary.cshtml"
__backend_Infrastructure_PaginationTagHelper.PageClassesEnabled = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-classes-enabled", __backend_Infrastructure_PaginationTagHelper.PageClassesEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BurialViewModel> Html { get; private set; } = default!;
        #nullable disable
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:sex")]
        public class __Generated__SexViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__SexViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("Sex", ProcessInvokeAsyncArgs(__context));
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
            private Dictionary<string, object> ProcessInvokeAsyncArgs(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context)
            {
                Dictionary<string, object> args = new Dictionary<string, object>();
                return args;
            }
        }
    }
}
#pragma warning restore 1591
